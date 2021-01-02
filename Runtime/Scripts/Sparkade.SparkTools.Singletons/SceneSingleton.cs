namespace Sparkade.SparkTools.Singletons
{
    using UnityEngine;

    /// <summary>
    /// A Singleton which persists through the life of the Scene it was created in.
    /// </summary>
    /// <typeparam name="T">The type of the class that it is inheriting from.</typeparam>
    public abstract class SceneSingleton<T> : Singleton<T>
        where T : MonoBehaviour
    {
        /// <summary>
        /// To use the Awake method in your singleton override this and run the base before your own code.
        /// </summary>
        protected override void Awake()
        {
            if (Instance != this)
            {
                Debug.LogError($"More than one instance exists for the Singleton of type '{typeof(T)}', and will be destroyed");
                Destroy(this);
            }
        }
    }
}