using UnityEngine;

namespace LeoESCTest.Components
{
    public struct UnityObjectComponent<T> where T : Object
    {
        public T Object;
    }
}