using UnityEngine;

namespace CaputillaMelonLoader
{
    public class CaputillaHub : MonoBehaviour
    {
        internal static CaputillaHub? Instance;

        public static event Action? OnModdedJoin, OnModdedLeave, OnGameInitialized;
        public static bool InModdedRoom { get; private set; }

        internal void InvokeOnModdedJoin()
        {
            OnModdedJoin?.Invoke();
            InModdedRoom = true;
        }

        internal void InvokeOnModdedLeave()
        {
            OnModdedLeave?.Invoke();
            InModdedRoom = false;
        }

        internal void InvokeOnGameInitialized() => OnGameInitialized?.Invoke();

        private void Start() => Instance = this;
    }
}