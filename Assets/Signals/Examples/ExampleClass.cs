//   Project : Signals
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 9/11/2018

using UnityEngine;

namespace Homebrew{
public class ExampleClass : MonoBehaviour {
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SignalExampleDamage signalExample;
            signalExample.damage = Random.Range(1, 10);
            signalExample.go = gameObject;
            ProcessingSignals.Default.Send(signalExample);
        }
    }
}
}