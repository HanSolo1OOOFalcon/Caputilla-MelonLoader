using UnityEngine;
using Object = UnityEngine.Object;

namespace CaputillaMelonLoader.Utils
{
    public static class CaputillaExtensions
    {
        public static void Kill(this GameObject go)
        {
            if (go == null)
                return;
            
            List<GameObject> children = new List<GameObject>();
            foreach (Transform child in go.transform)
                children.Add(child.gameObject);
            
            foreach (GameObject child in children)
                child.Kill();
            
            children.Clear();
            
            Object.Destroy(go);
        }

        public static T GetOrAddComponent<T>(this GameObject go) where T : Component
        {
            T component = go.GetComponent<T>();
            if (component == null)
                component = go.AddComponent<T>();
            return component;
        }
    }
}