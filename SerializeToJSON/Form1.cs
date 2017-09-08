using Newtonsoft.Json;
using SerializeToJSON.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SerializeToJSON
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            List<User> users = new List<User>();
            this.Load += (s,e) => 
            {
                users.Add(new User { Id = Guid.NewGuid(), Username = "Tony", NickName = "Neta", Points = 20, Hours = 3 });
                users.Add(new User { Id = Guid.NewGuid(), Username = "Mathis", NickName = "Metal", Points = 16, Hours = 4 });
                users.Add(new User { Id = Guid.NewGuid(), Username = "Regis", NickName = "Aroba", Points = 14, Hours = 2 });
                users.Add(new User { Id = Guid.NewGuid(), Username = "Miguel", NickName = "ITCapa", Points = 18, Hours = 5 });

                // Add text to richTextBoxHowTo
                richTextBoxHowTo.Text = File.ReadAllText("Explications.txt");
            };

            buttonSerialize.Click += (s, e) =>
            {
                string myJsonString = JsonConvert.SerializeObject(users, Formatting.Indented);
                File.WriteAllText(@"C:\json.txt", myJsonString);
            };

            buttonDeserialize.Click += (s, e) =>
            {
                // Lire le fichier contenant le texte json et le deserializer.
                var stringJSON = File.ReadAllText(@"C:\json.txt");

                var userList = JsonConvert.DeserializeObject<List<User>>(stringJSON);
                users = userList;

                StringBuilder strJSON = new StringBuilder();
                foreach (var item in userList)
                {
                    strJSON.Append(item + Environment.NewLine);
                }
                MessageBox.Show(strJSON.ToString());
            };
        }
    }
}