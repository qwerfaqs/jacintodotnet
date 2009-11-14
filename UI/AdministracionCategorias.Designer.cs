namespace UI
{
    partial class AdministracionCategorias
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.grp_lista = new System.Windows.Forms.GroupBox();
            this.listBox_listado = new System.Windows.Forms.ListBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.grp_eliminacion = new System.Windows.Forms.GroupBox();
            this.label_nombre = new System.Windows.Forms.Label();
            this.label_id = new System.Windows.Forms.Label();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.grp_Modificacion = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_modif_nombre = new System.Windows.Forms.TextBox();
            this.txt_modif_id = new System.Windows.Forms.TextBox();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.grp_carga = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_carga_nombre = new System.Windows.Forms.TextBox();
            this.txt_carga_id = new System.Windows.Forms.TextBox();
            this.btn_carga = new System.Windows.Forms.Button();
            this.grp_lista.SuspendLayout();
            this.grp_eliminacion.SuspendLayout();
            this.grp_Modificacion.SuspendLayout();
            this.grp_carga.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_lista
            // 
            this.grp_lista.Controls.Add(this.listBox_listado);
            this.grp_lista.Location = new System.Drawing.Point(286, 12);
            this.grp_lista.Name = "grp_lista";
            this.grp_lista.Size = new System.Drawing.Size(173, 182);
            this.grp_lista.TabIndex = 11;
            this.grp_lista.TabStop = false;
            this.grp_lista.Text = "Listado";
            // 
            // listBox_listado
            // 
            this.listBox_listado.FormattingEnabled = true;
            this.listBox_listado.Location = new System.Drawing.Point(14, 20);
            this.listBox_listado.Name = "listBox_listado";
            this.listBox_listado.Size = new System.Drawing.Size(142, 147);
            this.listBox_listado.TabIndex = 6;
            this.listBox_listado.SelectedValueChanged += new System.EventHandler(this.listBox_listado_SelectedValueChanged);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(383, 200);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 12;
            this.btn_ok.Text = "Listo";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // grp_eliminacion
            // 
            this.grp_eliminacion.Controls.Add(this.label_nombre);
            this.grp_eliminacion.Controls.Add(this.label_id);
            this.grp_eliminacion.Controls.Add(this.btn_eliminar);
            this.grp_eliminacion.Location = new System.Drawing.Point(12, 161);
            this.grp_eliminacion.Name = "grp_eliminacion";
            this.grp_eliminacion.Size = new System.Drawing.Size(268, 54);
            this.grp_eliminacion.TabIndex = 10;
            this.grp_eliminacion.TabStop = false;
            this.grp_eliminacion.Text = "Eliminacion";
            // 
            // label_nombre
            // 
            this.label_nombre.AutoSize = true;
            this.label_nombre.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label_nombre.Location = new System.Drawing.Point(82, 24);
            this.label_nombre.Name = "label_nombre";
            this.label_nombre.Size = new System.Drawing.Size(0, 13);
            this.label_nombre.TabIndex = 6;
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label_id.Location = new System.Drawing.Point(24, 24);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(0, 13);
            this.label_id.TabIndex = 5;
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Location = new System.Drawing.Point(178, 19);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(75, 23);
            this.btn_eliminar.TabIndex = 0;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // grp_Modificacion
            // 
            this.grp_Modificacion.Controls.Add(this.label3);
            this.grp_Modificacion.Controls.Add(this.label4);
            this.grp_Modificacion.Controls.Add(this.txt_modif_nombre);
            this.grp_Modificacion.Controls.Add(this.txt_modif_id);
            this.grp_Modificacion.Controls.Add(this.btn_guardar);
            this.grp_Modificacion.Location = new System.Drawing.Point(12, 85);
            this.grp_Modificacion.Name = "grp_Modificacion";
            this.grp_Modificacion.Size = new System.Drawing.Size(268, 70);
            this.grp_Modificacion.TabIndex = 9;
            this.grp_Modificacion.TabStop = false;
            this.grp_Modificacion.Text = "Modificacion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Id";
            // 
            // txt_modif_nombre
            // 
            this.txt_modif_nombre.Location = new System.Drawing.Point(62, 29);
            this.txt_modif_nombre.MaxLength = 20;
            this.txt_modif_nombre.Name = "txt_modif_nombre";
            this.txt_modif_nombre.Size = new System.Drawing.Size(100, 20);
            this.txt_modif_nombre.TabIndex = 2;
            // 
            // txt_modif_id
            // 
            this.txt_modif_id.Enabled = false;
            this.txt_modif_id.Location = new System.Drawing.Point(11, 29);
            this.txt_modif_id.MaxLength = 5;
            this.txt_modif_id.Name = "txt_modif_id";
            this.txt_modif_id.Size = new System.Drawing.Size(45, 20);
            this.txt_modif_id.TabIndex = 1;
            // 
            // btn_guardar
            // 
            this.btn_guardar.Location = new System.Drawing.Point(178, 19);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(75, 39);
            this.btn_guardar.TabIndex = 0;
            this.btn_guardar.Text = "Guardar Cambios";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // grp_carga
            // 
            this.grp_carga.Controls.Add(this.label2);
            this.grp_carga.Controls.Add(this.label1);
            this.grp_carga.Controls.Add(this.txt_carga_nombre);
            this.grp_carga.Controls.Add(this.txt_carga_id);
            this.grp_carga.Controls.Add(this.btn_carga);
            this.grp_carga.Location = new System.Drawing.Point(12, 12);
            this.grp_carga.Name = "grp_carga";
            this.grp_carga.Size = new System.Drawing.Size(268, 67);
            this.grp_carga.TabIndex = 8;
            this.grp_carga.TabStop = false;
            this.grp_carga.Text = "Carga";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Id";
            // 
            // txt_carga_nombre
            // 
            this.txt_carga_nombre.Location = new System.Drawing.Point(62, 28);
            this.txt_carga_nombre.MaxLength = 20;
            this.txt_carga_nombre.Name = "txt_carga_nombre";
            this.txt_carga_nombre.Size = new System.Drawing.Size(100, 20);
            this.txt_carga_nombre.TabIndex = 2;
            // 
            // txt_carga_id
            // 
            this.txt_carga_id.Location = new System.Drawing.Point(11, 28);
            this.txt_carga_id.MaxLength = 5;
            this.txt_carga_id.Name = "txt_carga_id";
            this.txt_carga_id.Size = new System.Drawing.Size(45, 20);
            this.txt_carga_id.TabIndex = 1;
            // 
            // btn_carga
            // 
            this.btn_carga.Location = new System.Drawing.Point(178, 26);
            this.btn_carga.Name = "btn_carga";
            this.btn_carga.Size = new System.Drawing.Size(75, 23);
            this.btn_carga.TabIndex = 0;
            this.btn_carga.Text = "Cargar";
            this.btn_carga.UseVisualStyleBackColor = true;
            this.btn_carga.Click += new System.EventHandler(this.btn_carga_Click);
            // 
            // AdministracionCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 233);
            this.Controls.Add(this.grp_lista);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.grp_eliminacion);
            this.Controls.Add(this.grp_Modificacion);
            this.Controls.Add(this.grp_carga);
            this.Name = "AdministracionCategorias";
            this.Text = "Administracion - Categorias";
            this.Load += new System.EventHandler(this.Categorias_Load);
            this.grp_lista.ResumeLayout(false);
            this.grp_eliminacion.ResumeLayout(false);
            this.grp_eliminacion.PerformLayout();
            this.grp_Modificacion.ResumeLayout(false);
            this.grp_Modificacion.PerformLayout();
            this.grp_carga.ResumeLayout(false);
            this.grp_carga.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_lista;
        private System.Windows.Forms.ListBox listBox_listado;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.GroupBox grp_eliminacion;
        private System.Windows.Forms.Label label_nombre;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.GroupBox grp_Modificacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_modif_nombre;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.GroupBox grp_carga;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_carga_nombre;
        private System.Windows.Forms.TextBox txt_carga_id;
        private System.Windows.Forms.Button btn_carga;
        private System.Windows.Forms.TextBox txt_modif_id;
    }
}