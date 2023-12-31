using UnityEngine;

namespace VTLTools.ResoureAsset
{
    public class ResourceLoader<T> where T : Object
    {
        public ResourceLoader(string path)
        {
            this.path = path;
        }

        public T Value
        {
            get
            {
                T t;
                if ((t = this.asset) == null)
                {
                    t = Resources.Load<T>(this.path);
                }
                this.asset = t;
                return this.asset;
            }
        }

        private readonly string path;

        private T asset;
    }
}