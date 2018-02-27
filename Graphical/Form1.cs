using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagedCuda.CudaFFT;
using ManagedCuda.VectorTypes;
using simpleCUFFT;

namespace Graphical
{
    public partial class Form1 : Form
    {
        private const double Gamma = 0.80;
        private const double IntensityMax = 255;
        private const double Tolerance = 1E-6;
        private const double NanoConst = 1E-9;
        private const double MicroConst = 1E-6;
        private readonly Color _validationFailedColor = Color.FromArgb(100, Color.Maroon);

        private bool _usePhase = true;
        private double _lambda;
        private double _z;
        private double _deltaZ;
        private double _h;
        private int _n;


        private cuDoubleComplex[] _inputData;
        private double[] _spwPhaseShift;
        private double[] _phaseData;


        private void addPhaseShift(cuDoubleComplex[] data, double multiplier)
        {
            Parallel.For(0, _n, i =>
            {
                for (int j = 0; j < _n; j++)
                {
                    var phase = Math.Atan2(data[i * _n + j].imag, data[i * _n + j].real) +(multiplier*
                                Math.PI * (i + j));
                    var ampl = Math.Sqrt(data[i * _n + j].real * data[i * _n + j].real +
                                         data[i * _n + j].imag * data[i * _n + j].imag);
                    data[i * _n + j].real = (ampl * Math.Cos(phase));
                    data[i * _n + j].imag = (ampl * Math.Sin(phase));
                }
            });
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void loadAmplitudeButton_Click(object sender, EventArgs e)
        {
            if (loadAmplitudeDialog.ShowDialog() == DialogResult.OK)
            {
                inputAmplitudeImage.Load(loadAmplitudeDialog.FileName);
                var amplitudeImage = new Bitmap(inputAmplitudeImage.Image);
                var lockedBmp = new LockBitmap(amplitudeImage);
                lockedBmp.LockBits();
                _n = lockedBmp.Height;
                _inputData = new cuDoubleComplex[_n * _n];
                _spwPhaseShift = new double[_n * _n];

                double k = 2 * Math.PI / _lambda;
                double temp = _lambda * _lambda / _h / _h / _n / _n;
                Parallel.For(0, _n,
                    i =>
                    {
                        for (int j = 0; j < _n; j++)
                        {
                            var pixelValue = lockedBmp.GetPixel(i, j);
                            _inputData[i * _n + j].real = Math.Sqrt(pixelValue.G);
                            _inputData[i * _n + j].imag = 0f;
                            _spwPhaseShift[i * _n + j] =
                                k * _z * Math.Sqrt(
                                    1 - temp * ((_n / 2 - i) * (_n / 2 - i) + (_n / 2 - j) * (_n / 2 - j)));
                        }
                    });
                lockedBmp.UnlockBits();
            }
        }


        private void loadPhaseButton_Click(object sender, EventArgs e)
        {
            if (loadPhaseDialog.ShowDialog() == DialogResult.OK)
            {
                inputPhaseImage.Load(loadPhaseDialog.FileName);
                var phaseImage = new Bitmap(inputPhaseImage.Image);
                var lockedBmp = new LockBitmap(phaseImage);
                lockedBmp.LockBits();
                if (lockedBmp.Height != lockedBmp.Width && lockedBmp.Height != _n)
                {
                    throw new Exception("Изображения не одного размера!");
                }
                _phaseData = new double[_n * _n];

                Parallel.For(0, _n,
                    i =>
                    {
                        for (int j = 0; j < _n; j++)
                        {
                            var pixelValue = lockedBmp.GetPixel(i, j);
                            _phaseData[i * _n + j] = (double) pixelValue.G;
                        }
                    });
                lockedBmp.UnlockBits();
            }
        }

        private void goButton_Click(object sender, EventArgs e)
        {

            var amplitudeImage = new Bitmap(inputAmplitudeImage.Image);
            var lockedBmp = new LockBitmap(amplitudeImage);
            lockedBmp.LockBits();
            _n = lockedBmp.Height;
            _inputData = new cuDoubleComplex[_n * _n];
            _spwPhaseShift = new double[_n * _n];

            double k = 2 * Math.PI / _lambda;
            double temp = _lambda * _lambda / _h / _h / _n / _n;
            Parallel.For(0, _n, i =>
            {
                for (int j = 0; j < _n; j++)
                {
                    var pixelValue = lockedBmp.GetPixel(i, j);
                    _inputData[i * _n + j].real = Math.Sqrt(pixelValue.G);
                    _inputData[i * _n + j].imag = 0f;
                    _spwPhaseShift[i * _n + j] =
                        k * _z * Math.Sqrt(1 - temp * ((_n / 2 - i) * (_n / 2 - i) + (_n / 2 - j) * (_n / 2 - j)));
                }
            });
            lockedBmp.UnlockBits();


            if (_usePhase)
            {
                Parallel.For(0, _n, i =>
                {
                    for (int j = 0; j < _n; j++)
                    {
                        double phase = _phaseData[i * _n + j] / 255.0 * 2.0 * Math.PI;
                        double ampl = _inputData[i * _n + j].real;
                        _inputData[i * _n + j].real = (float) (ampl * Math.Cos(phase));
                        _inputData[i * _n + j].imag = (float) (ampl * Math.Sin(phase));
                    }
                });
            }

            var helper = new CudaHelper();

            //AddNegativePhaseShift

            addPhaseShift(_inputData,-1.0);

            /*Parallel.For(0, _n, i =>
            {
                for (int j = 0; j < _n; j++)
                {
                    var phase = Math.Atan2(_inputData[i * _n + j].imag, _inputData[i * _n + j].real) -
                                Math.PI * (i + j);
                    var ampl = Math.Sqrt(_inputData[i * _n + j].real * _inputData[i * _n + j].real +
                                         _inputData[i * _n + j].imag * _inputData[i * _n + j].imag);
                    _inputData[i * _n + j].real = (ampl * Math.Cos(phase));
                    _inputData[i * _n + j].imag = (ampl * Math.Sin(phase));
                }
            });*/

            //Perform Forward FFT
            _inputData = helper.PerformFFT(_inputData, _n, TransformDirection.Forward);


            //AddPhaseShiftingSPW
            var multZ = 4.5;
            Parallel.For(0, _n, i =>
            {
                for (int j = 0; j < _n; j++)
                {
                    var phase = Math.Atan2(_inputData[i * _n + j].imag, _inputData[i * _n + j].real) +
                                multZ * _spwPhaseShift[i * _n + j];
                    var ampl = Math.Sqrt(_inputData[i * _n + j].real * _inputData[i * _n + j].real +
                                         _inputData[i * _n + j].imag * _inputData[i * _n + j].imag);
                    _inputData[i * _n + j].real = (ampl * Math.Cos(phase));
                    _inputData[i * _n + j].imag = (ampl * Math.Sin(phase));
                }
            });

            //Perform inverse FFT
            _inputData = helper.PerformFFT(_inputData, _n, TransformDirection.Inverse);

            //AddPositivePhaseShift
            addPhaseShift(_inputData, 1.0);

            /*Parallel.For(0, _n, i =>
            {
                for (int j = 0; j < _n; j++)
                {
                    var phase = Math.Atan2(_inputData[i * _n + j].imag, _inputData[i * _n + j].real) +
                                Math.PI * (i + j);
                    var ampl = Math.Sqrt(_inputData[i * _n + j].real * _inputData[i * _n + j].real +
                                         _inputData[i * _n + j].imag * _inputData[i * _n + j].imag);
                    _inputData[i * _n + j].real = (ampl * Math.Cos(phase));
                    _inputData[i * _n + j].imag = (ampl * Math.Sin(phase));
                }
            });*/

            //Normalize FFT
            Parallel.For(0, _n, i =>
            {
                for (int j = 0; j < _n; j++)
                {

                    _inputData[i * _n + j].real /= _n * _n;
                    _inputData[i * _n + j].imag /= _n * _n;
                }
            });

            var outputAmplitude = new Bitmap(inputAmplitudeImage.Image);
            var lockedOutputBmp = new LockBitmap(outputAmplitude);
            lockedOutputBmp.LockBits();
            var max = 0;
            var intens = new int[_n * _n];

            Parallel.For(0, _n, i =>
            {
                for (int j = 0; j < _n; j++)
                {
                    intens[i * _n + j] = (int) Math.Floor(Math.Sqrt(
                        _inputData[i * _n + j].real * _inputData[i * _n + j].real +
                        _inputData[i * _n + j].imag * _inputData[i * _n + j].imag));
                    if (intens[i * _n + j] > max) max = intens[i * _n + j];
                }
            });

            var rgb = WaveLengthToRgb(_lambda / NanoConst);
            Parallel.For(0, _n, i =>
            {
                for (int j = 0; j < _n; j++)
                {
                    var intensity = intens[i * _n + j] * 1.0f / max;
                    var color = Color.FromArgb(255, (int) (intensity * rgb[0]), (int) (intensity * rgb[1]),
                        (int) (intensity * rgb[2]));
                    lockedOutputBmp.SetPixel(i, j, color);
                }
            });
            lockedOutputBmp.UnlockBits();



            var outputPhase = new Bitmap(inputAmplitudeImage.Image);
            lockedOutputBmp = new LockBitmap(outputPhase);
            lockedOutputBmp.LockBits();

            Parallel.For(0, _n, i =>
            {
                for (int j = 0; j < _n; j++)
                {

                    var x = Math.Atan2(_inputData[i * _n + j].imag, _inputData[i * _n + j].real) + Math.PI;
                    var intensity = (int) Math.Floor(x * 255 / 2 / Math.PI);
                    var color = Color.FromArgb(255, (int) (intensity), (int) (intensity), (int) (intensity));
                    lockedOutputBmp.SetPixel(i, j, color);
                }
            });
            lockedOutputBmp.UnlockBits();
            outputPhaseImage.Image = outputPhase;
            outputAmplitudeImage.Image = outputAmplitude;
            tabControl1.SelectedTab = outputTab;
        }

        private void usePhaseCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            _usePhase = !usePhaseCheckbox.Checked;
            loadPhaseButton.Enabled = _usePhase;
        }



        #region Validation

        private void lambdaInput_Validating(object sender, CancelEventArgs e)
        {
            lambdaInput.Text = lambdaInput.Text.Replace(".", ",");

            var validated = double.TryParse(lambdaInput.Text, out _lambda);
            if (!validated)
            {
                lambdaInputPanel.BackColor = _validationFailedColor;
            }
            else
            {
                lambdaInputPanel.ResetBackColor();
                _lambda *= NanoConst;
            }
        }

        private void zInput_Validating(object sender, CancelEventArgs e)
        {
            zInput.Text = zInput.Text.Replace(".", ",");

            var validated = double.TryParse(zInput.Text, out _z);
            if (!validated)
            {
                zInputPanel.BackColor = _validationFailedColor;
            }
            else
            {
                zInputPanel.ResetBackColor();
            }
        }

        private void deltaZInput_Validating(object sender, CancelEventArgs e)
        {
            deltaZInput.Text = deltaZInput.Text.Replace(".", ",");

            var validated = double.TryParse(deltaZInput.Text, out _deltaZ);
            if (!validated)
            {
                deltaZInputPanel.BackColor = _validationFailedColor;
            }
            else
            {
                deltaZInputPanel.ResetBackColor();
            }
        }

        private void hInput_Validating(object sender, CancelEventArgs e)
        {
            hInput.Text = hInput.Text.Replace(".", ",");

            var validated = double.TryParse(hInput.Text, out _h);
            if (!validated)
            {
                hInputPanel.BackColor = _validationFailedColor;
            }
            else
            {
                hInputPanel.ResetBackColor();
                _h *= MicroConst;
            }
        }

        #endregion

        #region Wavelength to RGB conversion

        private int[] WaveLengthToRgb(double wavelength)
        {
            double factor;
            double red, green, blue;
            var rgb = new int[3];
            if ((wavelength >= 380) && (wavelength < 440))
            {
                red = -(wavelength - 440) / (440 - 380);
                green = 0.0;
                blue = 1.0;
            }
            else if ((wavelength >= 440) && (wavelength < 490))
            {
                red = 0.0;
                green = (wavelength - 440) / (490 - 440);
                blue = 1.0;
            }
            else if ((wavelength >= 490) && (wavelength < 510))
            {
                red = 0.0;
                green = 1.0;
                blue = -(wavelength - 510) / (510 - 490);
            }
            else if ((wavelength >= 510) && (wavelength < 580))
            {
                red = (wavelength - 510) / (580 - 510);
                green = 1.0;
                blue = 0.0;
            }
            else if ((wavelength >= 580) && (wavelength < 645))
            {
                red = 1.0;
                green = -(wavelength - 645) / (645 - 580);
                blue = 0.0;
            }
            else if ((wavelength >= 645) && (wavelength < 781))
            {
                red = 1.0;
                green = 0.0;
                blue = 0.0;
            }
            else
            {
                red = 0.0;
                green = 0.0;
                blue = 0.0;
            }
            ;

            // Let the intensity fall off near the vision limits

            if ((wavelength >= 380) && (wavelength < 420))
            {
                factor = 0.3 + 0.7 * (wavelength - 380) / (420 - 380);
            }
            else if ((wavelength >= 420) && (wavelength < 701))
            {
                factor = 1.0;
            }
            else if ((wavelength >= 701) && (wavelength < 781))
            {
                factor = 0.3 + 0.7 * (780 - wavelength) / (780 - 700);
            }
            else
            {
                factor = 0.0;
            }
            ;

            // Don't want 0^x = 1 for x <> 0
            rgb[0] = Math.Abs(red) < Tolerance ? 0 : (int) Math.Round(IntensityMax * Math.Pow(red * factor, Gamma));
            rgb[1] = Math.Abs(green) < Tolerance ? 0 : (int) Math.Round(IntensityMax * Math.Pow(green * factor, Gamma));
            rgb[2] = Math.Abs(blue) < Tolerance ? 0 : (int) Math.Round(IntensityMax * Math.Pow(blue * factor, Gamma));

            return rgb;
        }

        #endregion

        private void forwardButton_Click(object sender, EventArgs e)
        {
            _z += _deltaZ;
            zInput.Text = _z.ToString(CultureInfo.InvariantCulture);
            goButton_Click(sender, e);
        }

        private void backwardButton_Click(object sender, EventArgs e)
        {
            _z -= _deltaZ;
            zInput.Text = _z.ToString(CultureInfo.InvariantCulture);
            goButton_Click(sender, e);
        }

        private void saveAmplitudeButton_Click(object sender, EventArgs e)
        {
            saveAmplitudeDialog.Filter = @"Bitmap Image|*.bmp";
            saveAmplitudeDialog.FileName = (_lambda / NanoConst).ToString(CultureInfo.InvariantCulture) + "nm; " +
                                           (_z.ToString(CultureInfo.InvariantCulture)) + "m; " +
                                           (_h / MicroConst).ToString(CultureInfo.InvariantCulture) + "pm; Amplitude";

            if (saveAmplitudeDialog.ShowDialog() == DialogResult.OK)
            {
                outputAmplitudeImage.Image.Save(saveAmplitudeDialog.FileName);
            }

        }

        private void savePhaseButton_Click(object sender, EventArgs e)
        {
            savePhaseDialog.Filter = @"Bitmap Image|*.bmp";
            saveAmplitudeDialog.FileName = (_lambda / NanoConst).ToString(CultureInfo.InvariantCulture) + "nm; " +
                                           (_z.ToString(CultureInfo.InvariantCulture)) + "m; " +
                                           (_h / MicroConst).ToString(CultureInfo.InvariantCulture) + "pm; Phase";
            if (savePhaseDialog.ShowDialog() == DialogResult.OK)
            {
                outputPhaseImage.Image.Save(saveAmplitudeDialog.FileName);
            }
        }
    }
}
