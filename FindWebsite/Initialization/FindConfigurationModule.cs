using EPiServer.Core;
using EPiServer.Find;
using EPiServer.Find.ClientConventions;
using EPiServer.Find.Cms;
using EPiServer.Find.Cms.Conventions;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;

namespace FindWebsite.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class FindConfigurationModule : IInitializableModule
    {
        private IClient _client;
        public void Initialize(InitializationEngine context)
        {
            _client = context.Locate.Advanced.GetInstance<IClient>();
            _client.Conventions.TypeValidationConventions = new TypeValidationConventions();

            //Add Isearchable interface for content that needs to indexed.
            ContentIndexer.Instance.Conventions.ForInstancesOf<PageData>().ShouldIndex(ShouldIndexPage);
            ContentIndexer.Instance.Conventions.ForInstancesOf<BlockData>().ShouldIndex(ShouldIndexBlock);
            ContentIndexer.Instance.Conventions.ForInstancesOf<MediaData>().ShouldIndex(ShouldIndexMediaData);
            ContentIndexer.Instance.Conventions.ForInstancesOf<ContentFolder>().ShouldIndex(ShouldIndexContentFolder);
        }

        public void Uninitialize(InitializationEngine context)
        {
            //Add uninitialization logic
        }

        private bool ShouldIndexPage(PageData page)
        {
            System.Diagnostics.Debug.WriteLine($"ShouldIndexPage: {page.Language} - {page.ContentLink} - {page.Name}");
            return true;
        }

        private bool ShouldIndexBlock(BlockData block)
        {
            System.Diagnostics.Debug.WriteLine($"ShouldIndexBlock: {((IContent)block).ContentLink} - {((IContent)block).Name}");
            return true;
        }

        private bool ShouldIndexMediaData(MediaData media)
        {
            System.Diagnostics.Debug.WriteLine($"ShouldIndexMedia: {media.ContentLink} - {media.Name}");
            return true;
        }

        private bool ShouldIndexContentFolder(ContentFolder contentFolder)
        {
            System.Diagnostics.Debug.WriteLine($"ShouldIndexContentFolder: {contentFolder.ContentLink} - {contentFolder.Name}");
            return true;
        }
    }
}