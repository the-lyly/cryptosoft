using System;
using System.IO;

class XOREncryption
{
    static void Main()
    {
        string filePath = "D:\\bureau\\teste.txt";
        string key = "MaCleDeChiffrement123";

        // Crypter le fichier
        EncryptFile(filePath, key);

        Console.WriteLine("Fichier crypté avec succès.");
    }

    static void EncryptFile(string filePath, string key)
    {
        try
        {
            byte[] fileBytes = File.ReadAllBytes(filePath);

            if (fileBytes.Length == 0)
            {
                Console.WriteLine("Le fichier est vide. Aucun chiffrement n'est nécessaire.");
                return;
            }

            byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(key);

            for (int i = 0; i < fileBytes.Length; i++)
            {
                fileBytes[i] = (byte)(fileBytes[i] ^ keyBytes[i % keyBytes.Length]);
            }

            // Créer une copie du fichier chiffré dans le même répertoire
            string encryptedFilePath = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + "_crypte" + Path.GetExtension(filePath));
            File.WriteAllBytes(encryptedFilePath, fileBytes);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la lecture ou de l'écriture du fichier : {ex.Message}");
        }
    }
}
