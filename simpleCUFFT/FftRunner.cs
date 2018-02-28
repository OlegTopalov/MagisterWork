using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using ManagedCuda;
using ManagedCuda.CudaFFT;
using ManagedCuda.VectorTypes;
using FFTW.NET;

namespace simpleCUFFT
{
    public static class FftRunner
    {
        private static CudaHelper cuHelper;
        private static bool cudaAvailable;
        static FftRunner()
        {
            try
            {
                cuHelper = new CudaHelper();
                cudaAvailable = true;
            }
            catch(Exception)
            {
                cudaAvailable = false;
            }
        }

        public static cuDoubleComplex[] PerformFft(cuDoubleComplex[] data,int size, TransformDirection direction)
        {
            if (cudaAvailable)
                return cuHelper.PerformFFT(data, size, direction);
            else
            {
                cuDoubleComplex[] result = new cuDoubleComplex[size * size];
                using (var input = new AlignedArrayComplex(16, size, size))
                using (var output = new AlignedArrayComplex(16, input.GetSize()))
                {
                    for (int i = 0; i < input.GetLength(0); i++)
                    {
                        for (int j = 0; j < input.GetLength(1); j++)
                        {
                            input[i, j] = new Complex(data[i * size + j].real, data[i * size + j].imag);
                        }
                    }
                    if(direction == TransformDirection.Forward)
                        DFT.FFT(input, output);
                    else
                    {
                        DFT.IFFT(input,output);
                    }
                    for (int i = 0; i < input.GetLength(0); i++)
                    {
                        for (int j = 0; j < input.GetLength(1); j++)
                        {
                            result[i * size + j].real = output[i, j].Real;
                            result[i * size + j].imag = output[i, j].Imaginary;
                        }
                    }
                }
                return result;
            }
        }
    }
}
