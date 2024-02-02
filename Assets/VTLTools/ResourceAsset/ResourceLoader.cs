using UnityEngine;

namespace VTLTools.ResourceAsset
{
    public class ResourceLoader<ResourceType> where ResourceType : Object
    {
        public ResourceLoader(string resourcePath)
        {
            this.resourcePath = resourcePath;
        }

        public ResourceType Resource
        {
            get
            {
                ResourceType resource;
                if ((resource = this.loadedResource) == null)
                {
                    resource = Resources.Load<ResourceType>(this.resourcePath);
                }
                this.loadedResource = resource;
                return this.loadedResource;
            }
        }

        private readonly string resourcePath;

        private ResourceType loadedResource;
    }
}
