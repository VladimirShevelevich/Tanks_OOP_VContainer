using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Tools.Disposable
{
    public class GameObjectDisposer : IDisposable
    {
        private readonly GameObject _gameObject;

        public GameObjectDisposer(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        public void Dispose()
        {
            if (_gameObject != null)
                Object.Destroy(_gameObject);
        }
    }
}