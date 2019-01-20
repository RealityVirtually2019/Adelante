using System.Collections;
using UnityEngine;
 
public class Emailer : MonoBehaviour {

    public bool debug = false;

    public string toEmail = "";
    public string subject = "";
    public string body = "";


    private string fromEmail = "Adelante@realityvirtuallyhack.com";

    private string xsmtpapiJSON = "{\"category\":\"game_email\"}";
    private string api_user = "deprecatedcoder";
    private string api_key = "iNj3yAZLpC7WxeY";


    [ContextMenu("Send mail")] 
    public void SendMail()
    {
        string url = "https://sendgrid.com/api/mail.send.json?";
  
        url += "to=" + toEmail;
        url += "&from=" + fromEmail;
  
        //you have to change every instance of space to %20 or you'll get a 400 error
        string subjectWithoutSpace = subject.Replace(" ", "%20");
        url += "&subject=" + subjectWithoutSpace;

        string bodyWithoutSpace = body.Replace(" ", "%20");
  
        url += "&text=" + bodyWithoutSpace;
        url += "&x-smtpapi=" + xsmtpapiJSON;
        url += "&api_user=" + api_user;
        url += "&api_key=" + api_key;

        WWW www = new WWW(url);

        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            if (debug) Debug.Log("WWW Ok! Email sent through Web API: " + www.text);
        } else {
            if (debug) Debug.Log("WWW Error: "+ www.error);
        }    
    }

}