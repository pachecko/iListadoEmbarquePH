namespace iListadoEmbarquePH.GUI
{
    partial class fmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmPrincipal));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbProveedor = new System.Windows.Forms.Label();
            this.tbPedido = new System.Windows.Forms.TextBox();
            this.cbTienda = new System.Windows.Forms.ComboBox();
            this.btCargaDatos = new System.Windows.Forms.Button();
            this.btImprimir = new System.Windows.Forms.Button();
            this.btCerrar = new System.Windows.Forms.Button();
            this.lbDir = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbArchivo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblConexion = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proveedor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pedido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tienda";
            // 
            // lbProveedor
            // 
            this.lbProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProveedor.Location = new System.Drawing.Point(129, 17);
            this.lbProveedor.Name = "lbProveedor";
            this.lbProveedor.Size = new System.Drawing.Size(324, 16);
            this.lbProveedor.TabIndex = 3;
            this.lbProveedor.Text = "label4";
            // 
            // tbPedido
            // 
            this.tbPedido.Location = new System.Drawing.Point(133, 48);
            this.tbPedido.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPedido.Name = "tbPedido";
            this.tbPedido.Size = new System.Drawing.Size(320, 23);
            this.tbPedido.TabIndex = 1;
            this.tbPedido.TextChanged += new System.EventHandler(this.tbPedido_TextChanged);
            // 
            // cbTienda
            // 
            this.cbTienda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbTienda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbTienda.BackColor = System.Drawing.Color.Khaki;
            this.cbTienda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTienda.FormattingEnabled = true;
            this.cbTienda.Location = new System.Drawing.Point(133, 82);
            this.cbTienda.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbTienda.Name = "cbTienda";
            this.cbTienda.Size = new System.Drawing.Size(320, 24);
            this.cbTienda.TabIndex = 2;
            this.cbTienda.SelectedIndexChanged += new System.EventHandler(this.cbTienda_SelectedIndexChanged);
            this.cbTienda.TextChanged += new System.EventHandler(this.tbPedido_TextChanged);
            this.cbTienda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbTienda_KeyPress);
            // 
            // btCargaDatos
            // 
            this.btCargaDatos.Enabled = false;
            this.btCargaDatos.Location = new System.Drawing.Point(34, 207);
            this.btCargaDatos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btCargaDatos.Name = "btCargaDatos";
            this.btCargaDatos.Size = new System.Drawing.Size(115, 28);
            this.btCargaDatos.TabIndex = 5;
            this.btCargaDatos.Text = "Carga de datos";
            this.btCargaDatos.UseVisualStyleBackColor = true;
            this.btCargaDatos.Click += new System.EventHandler(this.btCargaDatos_Click);
            // 
            // btImprimir
            // 
            this.btImprimir.Enabled = false;
            this.btImprimir.Location = new System.Drawing.Point(154, 207);
            this.btImprimir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(111, 28);
            this.btImprimir.TabIndex = 6;
            this.btImprimir.Text = "Imprimir";
            this.btImprimir.UseVisualStyleBackColor = true;
            this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
            // 
            // btCerrar
            // 
            this.btCerrar.Location = new System.Drawing.Point(461, 207);
            this.btCerrar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(76, 28);
            this.btCerrar.TabIndex = 8;
            this.btCerrar.Text = "Cerrar";
            this.btCerrar.UseVisualStyleBackColor = true;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click);
            // 
            // lbDir
            // 
            this.lbDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDir.Location = new System.Drawing.Point(161, 158);
            this.lbDir.Name = "lbDir";
            this.lbDir.Size = new System.Drawing.Size(292, 16);
            this.lbDir.TabIndex = 12;
            this.lbDir.Text = "lbDir";
            this.lbDir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Directorio de trabajo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Archivo";
            // 
            // cbArchivo
            // 
            this.cbArchivo.FormattingEnabled = true;
            this.cbArchivo.Location = new System.Drawing.Point(133, 120);
            this.cbArchivo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbArchivo.Name = "cbArchivo";
            this.cbArchivo.Size = new System.Drawing.Size(322, 24);
            this.cbArchivo.TabIndex = 3;
            this.cbArchivo.DropDown += new System.EventHandler(this.cbArchivo_DropDown);
            this.cbArchivo.SelectedIndexChanged += new System.EventHandler(this.cbArchivo_SelectedIndexChanged);
            this.cbArchivo.TextChanged += new System.EventHandler(this.tbPedido_TextChanged);
            this.cbArchivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbTienda_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(461, 120);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "Actualizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblConexion
            // 
            this.lblConexion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblConexion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblConexion.ForeColor = System.Drawing.Color.Green;
            this.lblConexion.Location = new System.Drawing.Point(0, 250);
            this.lblConexion.Name = "lblConexion";
            this.lblConexion.Size = new System.Drawing.Size(553, 32);
            this.lblConexion.TabIndex = 20;
            this.lblConexion.Text = "Conexión";
            this.lblConexion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(0, 251);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(551, 30);
            this.progressBar.TabIndex = 21;
            this.progressBar.Visible = false;
            // 
            // btCancelar
            // 
            this.btCancelar.Enabled = false;
            this.btCancelar.Location = new System.Drawing.Point(270, 207);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(85, 28);
            this.btCancelar.TabIndex = 7;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // fmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 282);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblConexion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbArchivo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbDir);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btCerrar);
            this.Controls.Add(this.btImprimir);
            this.Controls.Add(this.btCargaDatos);
            this.Controls.Add(this.cbTienda);
            this.Controls.Add(this.tbPedido);
            this.Controls.Add(this.lbProveedor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "fmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Embarque Palacio de Hierro";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmPrincipal_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fmPrincipal_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbProveedor;
        private System.Windows.Forms.TextBox tbPedido;
        private System.Windows.Forms.ComboBox cbTienda;
        private System.Windows.Forms.Button btCargaDatos;
        private System.Windows.Forms.Button btImprimir;
        private System.Windows.Forms.Button btCerrar;
        private System.Windows.Forms.Label lbDir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbArchivo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblConexion;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btCancelar;
    }
}