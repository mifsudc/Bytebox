using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBox.lib
{
    class ManagedEncryptor
    {
        private byte[] keyHash;
        private byte[] intHash;
        private string salt;

        public string path { get; set; }
        public string pass { private get; set; }

        public bool encrypt(List<string> input)
        {
            if ( path == null || pass == null )
                return false;

            try {
                (keyHash, salt, intHash) = EncryptionWrapper.preparePassword( pass );
                EncryptionWrapper.encryptToFile( path, input, keyHash, salt, intHash );
            }
            catch {
                return false;
            }
            return true;
        }

        public List<string> decrypt()
        {
            List<string> output = new List<string>();

            if ( path != null && pass != null && keyHash != null )
            {
                try {
                    output = EncryptionWrapper.decryptFromFile( path, pass, keyHash );
                }
                catch { }
            }
            return output;
        }
    }
}
