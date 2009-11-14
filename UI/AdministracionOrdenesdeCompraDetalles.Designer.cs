namespace UI
{
    partial class AdministracionOrdenesdeCompraDetalles
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
            this.GrpBoxOrdenCompra = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.grpboxItems = new System.Windows.Forms.GroupBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.grpBoxCliente = new System.Windows.Forms.GroupBox();
            this.lblDomicilio = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.GrpBoxOrdenCompra.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.grpboxItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.grpBoxCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpBoxOrdenCompra
            // 
            this.GrpBoxOrdenCompra.Controls.Add(this.label13);
            this.GrpBoxOrdenCompra.Controls.Add(this.groupBox4);
            this.GrpBoxOrdenCompra.Controls.Add(this.lblEstado);
            this.GrpBoxOrdenCompra.Controls.Add(this.label11);
            this.GrpBoxOrdenCompra.Controls.Add(this.btnConfirmar);
            this.GrpBoxOrdenCompra.Controls.Add(this.grpboxItems);
            this.GrpBoxOrdenCompra.Controls.Add(this.grpBoxCliente);
            this.GrpBoxOrdenCompra.Location = new System.Drawing.Point(13, 14);
            this.GrpBoxOrdenCompra.Name = "GrpBoxOrdenCompra";
            this.GrpBoxOrdenCompra.Size = new System.Drawing.Size(478, 326);
            this.GrpBoxOrdenCompra.TabIndex = 0;
            this.GrpBoxOrdenCompra.TabStop = false;
            this.GrpBoxOrdenCompra.Text = "Orden de Compra";
            this.GrpBoxOrdenCompra.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(339, 294);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 20);
            this.label13.TabIndex = 12;
            this.label13.Text = "Total:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblTotal);
            this.groupBox4.Location = new System.Drawing.Point(387, 283);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(81, 35);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(6, 11);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(49, 20);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "00.00";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.Red;
            this.lblEstado.Location = new System.Drawing.Point(85, 16);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(81, 20);
            this.lblEstado.TabIndex = 11;
            this.lblEstado.Text = "Pendiente";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(11, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 20);
            this.label11.TabIndex = 10;
            this.label11.Text = "Estado: ";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(365, 13);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(103, 23);
            this.btnConfirmar.TabIndex = 2;
            this.btnConfirmar.Text = "Confirmar Orden";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            // 
            // grpboxItems
            // 
            this.grpboxItems.Controls.Add(this.dgvItems);
            this.grpboxItems.Location = new System.Drawing.Point(6, 117);
            this.grpboxItems.Name = "grpboxItems";
            this.grpboxItems.Size = new System.Drawing.Size(462, 167);
            this.grpboxItems.TabIndex = 1;
            this.grpboxItems.TabStop = false;
            this.grpboxItems.Text = "Items";
            // 
            // dgvItems
            // 
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Location = new System.Drawing.Point(6, 15);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.Size = new System.Drawing.Size(450, 144);
            this.dgvItems.TabIndex = 0;
            // 
            // grpBoxCliente
            // 
            this.grpBoxCliente.Controls.Add(this.lblDomicilio);
            this.grpBoxCliente.Controls.Add(this.lblId);
            this.grpBoxCliente.Controls.Add(this.lblMail);
            this.grpBoxCliente.Controls.Add(this.lblUser);
            this.grpBoxCliente.Controls.Add(this.lblNombre);
            this.grpBoxCliente.Controls.Add(this.label5);
            this.grpBoxCliente.Controls.Add(this.label4);
            this.grpBoxCliente.Controls.Add(this.label3);
            this.grpBoxCliente.Controls.Add(this.label2);
            this.grpBoxCliente.Controls.Add(this.label1);
            this.grpBoxCliente.Location = new System.Drawing.Point(6, 43);
            this.grpBoxCliente.Name = "grpBoxCliente";
            this.grpBoxCliente.Size = new System.Drawing.Size(462, 68);
            this.grpBoxCliente.TabIndex = 0;
            this.grpBoxCliente.TabStop = false;
            this.grpBoxCliente.Text = "Datos del Cliente";
            // 
            // lblDomicilio
            // 
            this.lblDomicilio.AutoSize = true;
            this.lblDomicilio.Location = new System.Drawing.Point(252, 42);
            this.lblDomicilio.Name = "lblDomicilio";
            this.lblDomicilio.Size = new System.Drawing.Size(195, 13);
            this.lblDomicilio.TabIndex = 9;
            this.lblDomicilio.Text = "Donovan y Camino Gral. Chamizo - Gerli";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(113, 42);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(19, 13);
            this.lblId.TabIndex = 8;
            this.lblId.Text = "00";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(252, 29);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(103, 13);
            this.lblMail.TabIndex = 7;
            this.lblMail.Text = "gates09@gmail.com";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(113, 29);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(47, 13);
            this.lblUser.TabIndex = 6;
            this.lblUser.Text = "Gates09";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(113, 16);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(51, 13);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Bill Gates";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Id de Usuario:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Domicilio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(207, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "E-Mail:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre de Usuario:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(394, 346);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(87, 23);
            this.btnSalir.TabIndex = 14;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // AdministracionOrdenesdeCompraDetalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 377);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.GrpBoxOrdenCompra);
            this.Name = "AdministracionOrdenesdeCompraDetalles";
            this.Text = "Administracion - Orden de Compra";
            this.Load += new System.EventHandler(this.AdministracionOrdenesdeCompraDetalles_Load);
            this.GrpBoxOrdenCompra.ResumeLayout(false);
            this.GrpBoxOrdenCompra.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.grpboxItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.grpBoxCliente.ResumeLayout(false);
            this.grpBoxCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpBoxOrdenCompra;
        private System.Windows.Forms.GroupBox grpBoxCliente;
        private System.Windows.Forms.GroupBox grpboxItems;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDomicilio;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}