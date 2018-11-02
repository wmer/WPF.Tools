using DependencyInjectionResolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace WPF.Tools.MVVM.Extra {
    public abstract class ResourceDictionary : System.Windows.ResourceDictionary {
        private DependencyInjection _injection;
        private Dictionary<string, Type> _registredViewModel;

        public ResourceDictionary() {
            _injection = new DependencyInjection();
            _registredViewModel = new Dictionary<string, Type>();
            RegisterResources();
        }

        /// <summary>
        /// <summary>
        /// Register resources with constructor parameterized
        /// How to use:
        /// caal method Register<T>(string key)
        /// <Example>
        /// Register<Resource1>("Resource1Key");
        /// Register<Resource2>("Resource2Key");
        /// Register<Resource3>("Resource3Key");
        /// ...
        /// </Example>
        /// <Observation>
        /// the key in Register<T>() must be the same in XAML
        /// </Observation>
        /// </summary>
        public abstract void RegisterResources();

        /// <summary>
        /// Register resource with constructor parameterized
        /// </summary>
        /// <typeparam name="T">ResourceType</typeparam>
        /// <param name="key">key of Resource, the same used in XAML</param>
        public void Register<T>(string key) {
            if (!_registredViewModel.ContainsKey(key)) {
                _registredViewModel[key] = typeof(T);
            }else {
                throw new Exception($"A key {key} já foi usada");
            }
        }

        protected override void OnGettingValue(object key, ref object value, out bool canCache) {
            if (_registredViewModel.ContainsKey($"{key}")) {
                GetValue($"{key}", ref value, out canCache);
            } else {
                base.OnGettingValue(key, ref value, out canCache);
            }
        }

        private void GetValue(string key, ref object value, out bool canCache) {
            value = _injection.Resolve(_registredViewModel[key], InstanceOptions.DiferentInstances);
            canCache = true;
        }
    }
}
