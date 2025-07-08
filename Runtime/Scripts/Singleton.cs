namespace Sparkade.SparkTools.Singletons
{
    using UnityEngine;

    /// <summary>
    /// A Singleton which persists through the life of the game.
    /// </summary>
    /// <typeparam name="T">The type of the class that it is inheriting from.</typeparam>
    public abstract class Singleton<T> : MonoBehaviour
        where T : MonoBehaviour
    {
        private static readonly object LockObject = new object();

        private static T instance;

        /// <summary>
        /// Gets the instance of a Singleton.
        /// </summary>
        public static T Instance
        {
            get
            {
                lock (LockObject)
                {
                    if (instance == null)
                    {
                        instance = FindAnyObjectByType<T>();

                        if (instance == null)
                        {
                            instance = new GameObject(typeof(T).Name).AddComponent<T>();
                        }
                    }

                    return instance;
                }
            }
        }

        /// <summary>
        /// To use the Awake method in your singleton override this and run the base before your own code.
        /// </summary>
        protected virtual void Awake()
        {
            if (Instance == this)
            {
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Debug.LogError($"More than one instance exists for the Singleton of type '{typeof(T)}', and will be destroyed");
                Destroy(this);
            }
        }
    }
}