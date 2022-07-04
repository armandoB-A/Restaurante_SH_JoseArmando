namespace Restaurante_SH_JoseArmando.FTR
{
    partial class Recetaa
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CbxProducto = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CbxIngredientes = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CbxPresentacion = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnAgregar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BtnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CbxProducto,
            this.CbxIngredientes,
            this.txtCantidad,
            this.CbxPresentacion,
            this.btnAgregar,
            this.BtnEliminar});
            this.dataGridView1.Location = new System.Drawing.Point(12, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1069, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // CbxProducto
            // 
            this.CbxProducto.HeaderText = "Produto";
            this.CbxProducto.MinimumWidth = 6;
            this.CbxProducto.Name = "CbxProducto";
            this.CbxProducto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CbxProducto.Width = 125;
            // 
            // CbxIngredientes
            // 
            this.CbxIngredientes.HeaderText = "Ingredientes";
            this.CbxIngredientes.MinimumWidth = 6;
            this.CbxIngredientes.Name = "CbxIngredientes";
            this.CbxIngredientes.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CbxIngredientes.Width = 125;
            // 
            // txtCantidad
            // 
            this.txtCantidad.HeaderText = "Cantidad";
            this.txtCantidad.MinimumWidth = 6;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Width = 125;
            // 
            // CbxPresentacion
            // 
            this.CbxPresentacion.HeaderText = "Presentacion";
            this.CbxPresentacion.MinimumWidth = 6;
            this.CbxPresentacion.Name = "CbxPresentacion";
            this.CbxPresentacion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CbxPresentacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CbxPresentacion.Width = 125;
            // 
            // btnAgregar
            // 
            this.btnAgregar.HeaderText = "agregar";
            this.btnAgregar.MinimumWidth = 6;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnAgregar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnAgregar.Text = "agregar";
            this.btnAgregar.UseColumnTextForButtonValue = true;
            this.btnAgregar.Width = 125;
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.HeaderText = "eliminar";
            this.BtnEliminar.MinimumWidth = 6;
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BtnEliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.BtnEliminar.Text = "eliminar";
            this.BtnEliminar.UseColumnTextForButtonValue = true;
            this.BtnEliminar.Width = 125;
            // 
            // Recetaa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Recetaa";
            this.Text = "Recetaa";
            this.Load += new System.EventHandler(this.Recetaa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewComboBoxColumn CbxProducto;
        private System.Windows.Forms.DataGridViewComboBoxColumn CbxIngredientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCantidad;
        private System.Windows.Forms.DataGridViewComboBoxColumn CbxPresentacion;
        private System.Windows.Forms.DataGridViewButtonColumn btnAgregar;
        private System.Windows.Forms.DataGridViewButtonColumn BtnEliminar;
    }
}