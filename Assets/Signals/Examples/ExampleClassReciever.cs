//   Project : Signals
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 9/11/2018

using UnityEngine;

namespace Homebrew
{
    public class ExampleClassReciever : MonoBehaviour, IReceive<SignalExampleDamage>
    {
        private void OnEnable()
        {
            ProcessingSignals.Default.Add(this);
        }

        private void OnDisable()
        {
            ProcessingSignals.Default.Remove(this);  
        }

        public void HandleSignal(SignalExampleDamage arg)
        {
            Debug.Log(arg.go + " deal "+ arg.damage + " damage!");
        }
    }
}