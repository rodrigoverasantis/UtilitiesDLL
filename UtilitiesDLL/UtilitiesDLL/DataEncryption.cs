using System;
using System.Linq;
using System.Security.Cryptography;

namespace UtilitiesDLL {
  public static class DataEncryption {

    #region CONSTANTES
    private const int SALT_BYTES = 32;//tamaño del array salt
    private const int PBKDF2_ITERATIONS = 64000;//cantidad de iteraciones en algoritmo
    private const int HASH_BYTES = 18;//tamaño del array hash
    #endregion

    /// <summary>
    /// Método encargado de encriptar un INPUT ingresado por usuario.
    /// Se el incluye la SALT para aumentar la complejidad.
    /// </summary>
    /// <param name="_input">Valor que será encriptado</param>
    /// <exception cref="ArgumentNullException">Se genera en caso de enviar un texto no válido (null o vacío)</exception>
    /// <exception cref="Exception.Exception(string, Exception)">Se genera en caso de fallar la ejecución del método</exception>
    /// <returns></returns>
    public static string EncryptInput(string _input) {
      try {
        if (string.IsNullOrEmpty(_input) == true || string.IsNullOrWhiteSpace(_input) == true) {
          throw new ArgumentNullException("Error, texto enviado no válido.");
        }
        var encryptedInput = new byte[DataEncryption.SALT_BYTES + DataEncryption.HASH_BYTES];

        byte[] salt = DataEncryption.SaltGenerator();
        byte[] hash = DataEncryption.InputHashing(_input,salt);

        Array.Copy(salt,0,encryptedInput,0,DataEncryption.SALT_BYTES);
        Array.Copy(hash,0,encryptedInput,DataEncryption.SALT_BYTES,DataEncryption.HASH_BYTES);

        var encryptedString = Convert.ToBase64String(encryptedInput);
        return encryptedString;
      } catch (Exception e) {
        throw new Exception("Error al intentar encriptar y codificar el texto enviado por parámetro.",e);
      }
    }

    /// <summary>
    /// Método encargado de verificar si el texto encriptado y el texto enviado son iguales.
    /// </summary>
    /// <param name="_encryptedInput">Texto encriptado que será verificado</param>
    /// <param name="_input">Texto que será utilizado para comparar con el texto encriptado</param>
    /// <returns></returns>
    public static bool VerifyEncryptedInput(string _encryptedInput,string _input) {
      try {
        if (string.IsNullOrEmpty(_encryptedInput) == true || string.IsNullOrWhiteSpace(_encryptedInput) == true) {
          throw new ArgumentNullException("Error, texto encriptado no válido.");
        }
        if (string.IsNullOrEmpty(_input) == true || string.IsNullOrWhiteSpace(_input) == true) {
          throw new ArgumentNullException("Error, texto ingresado no válido.");
        }
        var byteEncryptedInput = Convert.FromBase64String(_encryptedInput);
        var salt = new byte[DataEncryption.SALT_BYTES];

        Array.Copy(byteEncryptedInput,0,salt,0,DataEncryption.SALT_BYTES);

        var encryptedInputArray = DataEncryption.InputHashing(_input,salt);
        var inputArray = new byte[DataEncryption.SALT_BYTES + DataEncryption.HASH_BYTES];

        Array.Copy(salt,0,inputArray,0,DataEncryption.SALT_BYTES);
        Array.Copy(encryptedInputArray,0,inputArray,DataEncryption.SALT_BYTES,DataEncryption.HASH_BYTES);

        //TODO: se podría usar SlowEquals
        var check = byteEncryptedInput.SequenceEqual(inputArray);
        return check;
      } catch (Exception e) {
        throw new Exception("Error al intentar verificar en texto ingresado con el texto encriptado",e);
      }
    }

    #region PRIVATE FUNCTIONS
    /// <summary>
    /// Método encargado de generar un array Salt para el INPUT que se encriptará.
    /// </summary>
    /// <exception cref="Exception.Exception(string, Exception)">Se genera en caso de fallar la ejecución del método</exception>
    /// <returns></returns>
    private static byte[] SaltGenerator() {
      try {
        var salt = new byte[DataEncryption.SALT_BYTES];
        using (var csprng = new RNGCryptoServiceProvider()) {
          csprng.GetBytes(salt);
        }
        return salt;
      } catch (Exception e) {
        throw new Exception("Error al intentar generar un valor necesario para encriptar.",e);
      }
    }

    /// <summary>
    /// Método encargado de aplicar Hash al INPUT.
    /// </summary>
    /// <param name="_input">Valor que será encriptado</param>
    /// <param name="_salt">Parámetro que se utiliza para encriptar</param>
    /// <exception cref="Exception.Exception(string, Exception)">Se genera en caso de fallar la ejecución del método</exception>
    /// <returns></returns>
    private static byte[] InputHashing(string _input,byte[] _salt) {
      try {
        using (var pbkdf2 = new Rfc2898DeriveBytes(_input,_salt,DataEncryption.PBKDF2_ITERATIONS)) {
          return pbkdf2.GetBytes(DataEncryption.HASH_BYTES);
        }
      } catch (Exception e) {
        throw new Exception("Error al intentar encriptar el texto enviado por parámetro.",e);
      }
    }

    /// <summary>
    /// Método encargado de realizar una comparación de dos byte[], byte por byte.
    /// </summary>
    /// <param name="_input1">Valor que será comparado</param>
    /// <param name="_input2">Valor que será comparado</param>
    /// <exception cref="Exception.Exception(string, Exception)">Se genera en caso de fallar la ejecucion del método</exception>
    /// <returns></returns>
    private static bool SlowEquals(byte[] _input1,byte[] _input2) {
      try {
        uint diff = (uint)_input1.Length ^ (uint)_input2.Length;
        for (int i = 0;i < _input1.Length && i < _input2.Length;i++) {
          diff |= (uint)(_input1[i] ^ _input2[i]);
        }
        return diff == 0;
      } catch (Exception e) {
        throw new Exception("Error al intentar realizar la comparación de dos valores.",e);
      }
    }
    #endregion
  }
}
