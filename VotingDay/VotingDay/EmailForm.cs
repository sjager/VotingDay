using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VotingDay
{
    public partial class EmailForm : Form
    {
        public string Filepath;
        public EmailForm(string filepath)
        {
            InitializeComponent();
            Filepath = filepath;
            attachmenTextBox.Text = Filepath;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                //Sending the email.
                //Now we must create a new Smtp client to send our email.

                var client = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("teamamirite1@gmail.com", "Amirite?")
                };

                //Authentication.
                //This is where the valid email account comes into play. You must have a valid email account(with password) to give our program a place to send the mail from.

                //To send an email we must first create a new mailMessage(an email) to send.
                MailMessage Msg = new MailMessage();

                // Sender e-mail address.
                Msg.From = new MailAddress("teamamirite1@gmail.com");//Nothing But Above Credentials or your credentials (*******@gmail.com)

                // Recipient e-mail address.
                Msg.To.Add(recipientTextBox.Text);

                // Assign the subject of our message.
                Msg.Subject = subjectTextBox.Text;

                // Create the content(body) of our message.
                Msg.Body = bodyTextBox.Text;


                if(!attachmenTextBox.Text.Equals(""))
                {
                    Attachment attch = new Attachment(attachmenTextBox.Text);
                    Msg.Attachments.Add(attch);
                }

                //Confirmation After Click the Button
                statusLabel.Text = "Sent!";

                // Send our email.
                client.Send(Msg);

            }
            catch(Exception ex)
            {
                // If Mail Doesnt Send Error Mesage Will Be Displayed
                statusLabel.Text = "Error!";
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                attachmenTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
