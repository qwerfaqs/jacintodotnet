namespace UI
{
    partial class AdministracionOrdenesdeCompra
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
            this.dgvOrdenes = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPendientes = new System.Windows.Forms.CheckBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnDetalles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOrdenes
            // 
            this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenes.Location = new System.Drawing.Point(8, 19);
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.Size = new System.Drawing.Size(464, 150);
            this.dgvOrdenes.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDetalles);
            this.groupBox1.Controls.Add(this.chkPendientes);
            this.groupBox1.Controls.Add(this.dgvOrdenes);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 205);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Ordenes de Compra";
            // 
            // chkPendientes
            // 
            this.chkPendientes.AutoSize = true;
            this.chkPendientes.Location = new System.Drawing.Point(288, 179);
            this.chkPendientes.Name = "chkPendientes";
            this.chkPendientes.Size = new System.Drawing.Size(184, 17);
            this.chkPendientes.TabIndex = 1;
            this.chkPendientes.Text = "Mostrar Solo Ordenes Pendientes";
            this.chkPendientes.UseVisualStyleBackColor = true;
            this.chkPendientes.CheckedChanged += new System.EventHandler(this.chkPendientes_CheckedChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(416, 223);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnDetalles
            // 
            this.btnDetalles.Location = new System.Drawing.Point(8, 175);
            this.btnDetalles.Name = "btnDetalles";
            this.btnDetalles.Size = new System.Drawing.Size(100, 23);
            this.btnDetalles.TabIndex = 3;
            this.btnDetalles.Text = "Ver Detalles...";
            this.btnDetalles.UseVisualStyleBackColor = true;
            // 
            // AdministracionOrdenesdeCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 254);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox1);
            this.Name = "AdministracionOrdenesdeCompra";
            this.Text = "Administracion - Ordenes de Compra";
            this.Load += new System.EventHandler(this.AdministracionOrdenesdeCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrdenes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkPendientes;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnDetalles;
    }
}