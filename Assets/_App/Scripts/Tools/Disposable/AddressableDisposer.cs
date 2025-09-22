using System;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Tools.Disposable
{
    public class AddressableDisposer : IDisposable
    {
        private readonly AsyncOperationHandle _operationHandle;

        public AddressableDisposer(AsyncOperationHandle operationHandle)
        {
            _operationHandle = operationHandle;
        }
        
        public void Dispose()
        {
            _operationHandle.Release();
        }
    }
}