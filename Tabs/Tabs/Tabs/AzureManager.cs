using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabs
{
    public class AzureManager
    {

        private static AzureManager instance;
        private MobileServiceClient client;
        private IMobileServiceTable<YayOrNayModel> yayornayTable;


        private AzureManager()
        {
            this.client = new MobileServiceClient("http://yayornay.azurewebsites.net");
            this.yayornayTable = this.client.GetTable<YayOrNayModel>();
        }

        public MobileServiceClient AzureClient
        {
            get { return client; }
        }

        public static AzureManager AzureManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureManager();
                }

                return instance;
            }
        }

        public async Task<List<YayOrNayModel>> GetEmotionInformation()
        {
            return await this.yayornayTable.ToListAsync();
        }
        
    }
}
