# Signals

[![Join the chat at https://gitter.im/ActorsFramework/Lobby](https://img.shields.io/badge/gitter-join%20chat-green.svg?style=flat-square)](https://gitter.im/ActorsFramework/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![Join the chat at https://discord.gg/ukhzx83](https://img.shields.io/badge/discord-join%20channel-brightgreen.svg?style=flat-square)](https://discord.gg/ukhzx83)
[![Twitter Follow](https://img.shields.io/badge/twitter-%40dimmPixeye-blue.svg?style=flat-square&label=Follow)](https://twitter.com/dimmPixeye)
[![license](https://img.shields.io/badge/license-MIT-brightgreen.svg?style=flat-square)](https://github.com/dimmpixeye/Actors-Unity3d-Framework/blob/master/LICENSE)

## What are signals?

Signals allow you to communicate between decoupled parts of the game in Unity3d. The work with signals is very straightforward and can be shown in few steps:

* Step 1 - Write a signal. It's a plain struct.
```csharp
 public struct SignalExampleDamage
    {
        public GameObject go;
        public int damage;
    }
```

* Step 2 - Inherit from IRecieve<T> a class where you want your signal to be received.
  
```csharp
public class ExampleClassReciever : MonoBehaviour, IReceive<SignalExampleDamage>
    {
    
        private void OnEnable()
        {
            // Add this object to ProcessingSignals.Default
            ProcessingSignals.Default.Add(this);
        }

        private void OnDisable()
        {
           // Remove this object from ProcessingSignals.Default. You don't want this object to receive signals anymore!
             ProcessingSignals.Default.Remove(this);  
        }
        // This method will work when the signal is received.
        public void HandleSignal(SignalExampleDamage arg)
        {
            Debug.Log(string.Format({0} deals {1} damage!, arg.go, arg.damage));
        }
    }
```
 
* Step 3 - Create a new signal and send it through ProcessingSignals.Default 

```csharp
public class ExampleClass : MonoBehaviour {
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // create new signal
            SignalExampleDamage signalExample;
            signalExample.damage = Random.Range(1, 10);
            signalExample.go = gameObject;
            // send signal to the processor
            ProcessingSignals.Default.Send(signalExample);
        }
    }
}
```


## Other content
* [Foldout groups](https://github.com/dimmpixeye/InspectorFoldoutGroup) - an extension to add foldable groups to the inspector.
* [ACTORS](https://github.com/dimmpixeye/Actors-Unity3d-Framework) - Unity3d data-driven framework I'm currently working on. Signals work as part of the framework.
