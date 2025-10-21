using UnityEngine;
using AYellowpaper;
using System.Collections.Generic;
using com.ab.mvcshop.core.command;

namespace com.ab.mvcshop.modules.shop.definition
{
    [CreateAssetMenu(fileName = "#Name#BundleDef", menuName = "Bundles/Bundle")]
    public class BundleSo : ScriptableObject
    {
        public string MessageLK;
        
        [RequireInterface(typeof(ICommand))] public List<ScriptableObject> Conditions;
        [RequireInterface(typeof(ICommand))] public List<ScriptableObject> Results;
    }
}