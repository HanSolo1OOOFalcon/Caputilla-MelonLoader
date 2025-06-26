using UnityEngine;

namespace CaputillaMelonLoader
{
    public class CaputillaHub : MonoBehaviour
    {
        public static CaputillaHub? Instance;

        public static event Action? OnModdedJoin, OnModdedLeave, OnGameInitialized;
        public bool inModdedRoom { get; private set; }

        internal void InvokeOnModdedJoin()
        {
            OnModdedJoin?.Invoke();
            inModdedRoom = true;
        }

        internal void InvokeOnModdedLeave()
        {
            OnModdedLeave?.Invoke();
            inModdedRoom = false;
        }

        internal void InvokeOnGameInitialized() => OnGameInitialized?.Invoke();

        private void Start() => Instance = this;
    }
}