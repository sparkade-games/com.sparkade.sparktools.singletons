# SparkTools: Singletons
A quick and easy singleton solution.

# Installation
It is recommened to install through the Unity Package Manager.

If you wish to manually install, clone the repository into the 'Packages' folder of your project.

# How it works
Every class inheriting from a Singleton will only allow one of itself to ever exist. If one is created and another already exists, it will delete itself.

# How to Use
There are two types of singletons you can use:

- **Singleton:** A MonoBehaviour that exists throughout the life of the game. It will only be destroyed once the game has closed.

- **SceneSingleton:** Similar to a Singleton, but it is destroyed once the scene it was created in has unloaded.

To make use of these simply have your desired class inherit from either one. The 'T' in `Singleton<T>` and `SceneSingleton<T>` should be set to the same type it is inheriting from, i.e. `MySingletonClass : Singleton<MySingletonClass>`.

To access your Singleton from anywhere in the project, simply use `MySingletonClass.Instance`. If an instance already exists in the loaded scenes, it will use that, if not, it will create a new instance.

# Examples
Defining a Singleton
```
MySingleton : Singleton<MySingleton>
{
  public float Value = 10.0f;
}
```

Accessing a Singleton
```
Example : MonoBehaviour
{
  void Start()
  {
    Debug.Log(MySingleton.Instance.Value); // prints '10'
    MySingleton.Instance.Value = 200.0f;
    Debug.Log(MySingleton.Instance.Value); // prints '200'
  }
}
```
