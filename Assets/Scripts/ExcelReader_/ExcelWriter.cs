using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

using System.Net.Mail;
using System.Net;

public class ExcelWriter : MonoBehaviour
{
    private static TextWriter tw;
    private static string path;
    private static string nombreFile;
    void Start()
    {
        nombreFile = "";
    }
    public static void WriteCVS(string accesorios)
    {
        tw = new StreamWriter(path, true);//abrir el documento
        tw.WriteLine(accesorios);// calls continuos en una misma linea no hara saltos
        tw.Close();
    }

    public static void CreateFile(string nombreFileInput)
    {
        if (nombreFile != nombreFileInput)
        {
            /*path = UnityEngine.Application.dataPath + "\\Excels";
            nombreFile = nombreFileInput;
            StringBuilder cvscontent = new StringBuilder();//para usar strings de forma no tan costosa para el sistema, por la expliocacion de nilton porque en relaidad se podria poner un string normal y tambien funiona pero boe
            path +=  string.Format("\\{0}.csv", nombreFileInput);

            File.AppendAllText(path, cvscontent.ToString());

            tw = new StreamWriter(path, false);//borrar lo que había anteriormente 
            tw.Close();*/



            nombreFile = nombreFileInput;
            StringBuilder cvscontent = new StringBuilder();//para usar strings de forma no tan costosa para el sistema, por la expliocacion de nilton porque en relaidad se podria poner un string normal y tambien funiona pero boe


            //string PathParaForlder = Application.streamingAssetsPath + "\\Excel_Analisis";
            //Directory.CreateDirectory(PathParaForlder);


            //path = Path.Combine(Application.streamingAssetsPath, "\\Excel_Analisis", string.Format("\\{0}.csv", nombreFileInput));
            path = Path.Combine(Application.streamingAssetsPath, @"..\..\") + string.Format("\\{0}.csv", nombreFileInput);

            Debug.Log("Path del excel: " + path);

            File.AppendAllText(path, cvscontent.ToString());

            tw = new StreamWriter(path, false);//borrar lo que había anteriormente 
            tw.Close();
        }
    }


    [ContextMenu("Enviar Mail - FUNCTION")]
    public static void sendMail()//destino por default 
    {
        string fromEmail = "jostinoriguela@gmail.com";
        string fromPassword = "jerhwuufmcjuvvno";

        MailMessage message = new MailMessage();
        message.From = new MailAddress(fromEmail);
        message.Subject = "Informe de operario";
        message.To.Add(new MailAddress("jostin.ninamango@tecsup.edu.pe"));
        message.Body = "";
        Attachment attachment = new Attachment(path);
        message.Attachments.Add(attachment);


        var smptClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(fromEmail, fromPassword),
            EnableSsl = true,
        };

        smptClient.Send(message);
    }
}

