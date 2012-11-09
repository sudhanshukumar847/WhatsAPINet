using NUnit.Framework;

using WhatsAppApi.Helper;

namespace WhatsUnitTest {
    [TestFixture]
    public class NUnitSampleTests {

        byte [] TestKey = Util.StringToByteArray("4EB0EAD08B9FB4DAF2146245D2E69DD7B88438F0");

        [Test]
        public void EncryptionTest() {

            string[] messages = { "D814F2CE24AF7153B37BEEB20149BA669436172C8655BC09ACE66B23CEC8C0EA",
                                         "D814F2CE24AF7153B37BEEB20149BA669436172C8655BC09ACE66B23CEC8C0EA",
                                         "D814F2CE24AF7153B37BEEB20149BA669436172C8655BC09ACE66B23CEC8C0EA" };
            string[] answers = {"F227B9F6D30231288B0FE60A466B343C6B550A89778F71F16916E5066E9268208498686F",
                                    "EAC74BC62C02AB7D724DE2382A51CD8834C804DC49DCEF7CDBAE2E5E2E43D3789BBF3AD0",
                                    "C7EDB8049277F0B20ABFF211907B829397EB9144D522B6AA40CB53B410D869FE747A10AD"};

            Encryption._Reset();

            var a1 = Encryption.WhatsappEncrypt(TestKey, Util.StringToByteArray(messages[0]), false);
            var aa1 = Util.ByteArrayToString(a1);
            Assert.AreEqual(aa1.ToUpper(), answers[0]);

            var a2 = Encryption.WhatsappEncrypt(TestKey, Util.StringToByteArray(messages[1]), true);
            var aa2 = Util.ByteArrayToString(a2);
            Assert.AreEqual(aa2.ToUpper(), answers[1]);

            var a3 = Encryption.WhatsappEncrypt(TestKey, Util.StringToByteArray(messages[2]), true);
            var aa3 = Util.ByteArrayToString(a3);
            Assert.AreEqual(aa3.ToUpper(), answers[2]);
        }

    } //! class
} //! namespace
