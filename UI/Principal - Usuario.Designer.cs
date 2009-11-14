namespace UI
{
    partial class Principal___Usuario
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
            this.cmb_categorias = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btn_EliminarCarrito = new System.Windows.Forms.Button();
            this.bt_modificarItem = new System.Windows.Forms.Button();
            this.btn_vaciarCarrito = new System.Windows.Forms.Button();
            this.btn_generarorden = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_categorias
            // 
            this.cmb_categorias.FormattingEnabled = true;
            this.cmb_categorias.Location = new System.Drawing.Point(2, 621);
            this.cmb_categorias.Name = "cmb_categorias";
            this.cmb_categorias.Size = new System.Drawing.Size(179, 21);
            this.cmb_categorias.TabIndex = 0;
            this.cmb_categorias.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 1);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1029, 336);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowDrop = true;
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(2, 343);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1029, 272);
            this.dataGridView2.TabIndex = 2;
            this.dataGridView2.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView2_DragEnter);
            this.dataGridView2.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView2_DragDrop);
            // 
            // btn_EliminarCarrito
            // 
            this.btn_EliminarCarrito.Location = new System.Drawing.Point(187, 619);
            this.btn_EliminarCarrito.Name = "btn_EliminarCarrito";
            this.btn_EliminarCarrito.Size = new System.Drawing.Size(103, 23);
            this.btn_EliminarCarrito.TabIndex = 3;
            this.btn_EliminarCarrito.Text = "Eliminar del Carrito";
            this.btn_EliminarCarrito.UseVisualStyleBackColor = true;
            this.btn_EliminarCarrito.Click += new System.EventHandler(this.btn_EliminarCarrito_Click);
            // 
            // bt_modificarItem
            // 
            this.bt_modificarItem.Location = new System.Drawing.Point(296, 619);
            this.bt_modificarItem.Name = "bt_modificarItem";
            this.bt_modificarItem.Size = new System.Drawing.Size(103, 23);
            this.bt_modificarItem.TabIndex = 4;
            this.bt_modificarItem.Text = "Modificar Item";
            this.bt_modificarItem.UseVisualStyleBackColor = true;
            this.bt_modificarItem.Click += new System.EventHandler(this.bt_modificarItem_Click);
            // 
            // btn_vaciarCarrito
            // 
            this.btn_vaciarCarrito.Location = new System.Drawing.Point(405, 619);
            this.btn_vaciarCarrito.Name = "btn_vaciarCarrito";
            this.btn_vaciarCarrito.Size = new System.Drawing.Size(103, 23);
            this.btn_vaciarCarrito.TabIndex = 5;
            this.btn_vaciarCarrito.Text = "Vaciar Carrito";
            this.btn_vaciarCarrito.UseVisualStyleBackColor = true;
            this.btn_vaciarCarrito.Click += new System.EventHandler(this.btn_vaciarCarrito_Click);
            // 
            // btn_generarorden
            // 
            this.btn_generarorden.Location = new System.Drawing.Point(514, 619);
            this.btn_generarorden.Name = "btn_generarorden";
            this.btn_generarorden.Size = new System.Drawing.Size(103, 23);
            this.btn_generarorden.TabIndex = 6;
            this.btn_generarorden.Text = "Realizar Pedido";
            this.btn_generarorden.UseVisualStyleBackColor = true;
            this.btn_generarorden.Click += new System.EventHandler(this.btn_generarorden_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(850, 621);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "123465";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(760, 621);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 28);
            this.label2.TabIndex = 8;
            this.label2.Text = "Total :  $";
            // 
            // Principal___Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 653);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_generarorden);
            this.Controls.Add(this.btn_vaciarCarrito);
            this.Controls.Add(this.bt_modificarItem);
            this.Controls.Add(this.btn_EliminarCarrito);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmb_categorias);
            this.Name = "Principal___Usuario";
            this.Text = "Jacinto - Carrito de Compras";
            this.Load += new System.EventHandler(this.Principal___Usuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_categorias;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btn_EliminarCarrito;
        private System.Windows.Forms.Button bt_modificarItem;
        private System.Windows.Forms.Button btn_vaciarCarrito;
        private System.Windows.Forms.Button btn_generarorden;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}