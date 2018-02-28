using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using ManagedCuda;
using ManagedCuda.BasicTypes;
using ManagedCuda.VectorTypes;
using ManagedCuda.CudaFFT;

namespace simpleCUFFT
{
    public class CudaHelper
    {
        private CudaFFTPlan2D f_plan;
        private CudaContext ctx;

        public CudaHelper()
        {
            ctx = new CudaContext(0);
        }

        public cuDoubleComplex[] PerformFFT(cuDoubleComplex[] data, int n, TransformDirection direction)
        {
            
                f_plan = new CudaFFTPlan2D(n, n, cufftType.Z2Z);

            CudaDeviceVariable<cuDoubleComplex> d_signal = new CudaDeviceVariable<cuDoubleComplex>(n * n);
            CudaDeviceVariable<cuDoubleComplex> o_signal = new CudaDeviceVariable<cuDoubleComplex>(n * n);
            d_signal.CopyToDevice(data);
            f_plan.Exec(d_signal.DevicePointer,o_signal.DevicePointer, direction);


            cuDoubleComplex[] result = new cuDoubleComplex[n*n];

            o_signal.CopyToHost(result);
            d_signal.Dispose();
            return result;
        }

        ~CudaHelper()
        {
            f_plan?.Dispose();
            ctx?.Dispose();
        }

    }
}
