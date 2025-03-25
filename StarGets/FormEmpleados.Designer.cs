namespace StarGets
{
    partial class FormEmpleados
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
            this.components = new System.ComponentModel.Container();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtAp = new System.Windows.Forms.TextBox();
            this.txtAm = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.cbDepartamento = new System.Windows.Forms.ComboBox();
            this.cbRol = new System.Windows.Forms.ComboBox();
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
            this.empleadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.starGetsDataSet = new StarGets.StarGetsDataSet();
            this.empleadosTableAdapter = new StarGets.StarGetsDataSetTableAdapters.empleadosTableAdapter();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empleadosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.starGetsDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(208, 12);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(226, 22);
            this.txtNombre.TabIndex = 0;
            // 
            // txtAp
            // 
            this.txtAp.Location = new System.Drawing.Point(208, 56);
            this.txtAp.Name = "txtAp";
            this.txtAp.Size = new System.Drawing.Size(226, 22);
            this.txtAp.TabIndex = 1;
            // 
            // txtAm
            // 
            this.txtAm.Location = new System.Drawing.Point(208, 102);
            this.txtAm.Name = "txtAm";
            this.txtAm.Size = new System.Drawing.Size(226, 22);
            this.txtAm.TabIndex = 2;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(208, 150);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(226, 22);
            this.txtCorreo.TabIndex = 3;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(208, 200);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(226, 22);
            this.txtTelefono.TabIndex = 4;
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(208, 407);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(226, 22);
            this.txtContraseña.TabIndex = 6;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(208, 357);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(226, 22);
            this.txtUsuario.TabIndex = 5;
            // 
            // cbDepartamento
            // 
            this.cbDepartamento.FormattingEnabled = true;
            this.cbDepartamento.Location = new System.Drawing.Point(208, 250);
            this.cbDepartamento.Name = "cbDepartamento";
            this.cbDepartamento.Size = new System.Drawing.Size(226, 24);
            this.cbDepartamento.TabIndex = 7;
            // 
            // cbRol
            // 
            this.cbRol.FormattingEnabled = true;
            this.cbRol.Location = new System.Drawing.Point(208, 304);
            this.cbRol.Name = "cbRol";
            this.cbRol.Size = new System.Drawing.Size(226, 24);
            this.cbRol.TabIndex = 8;
            // 
            // dgvEmpleados
            // 
            this.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleados.Location = new System.Drawing.Point(13, 455);
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.RowHeadersWidth = 51;
            this.dgvEmpleados.RowTemplate.Height = 24;
            this.dgvEmpleados.Size = new System.Drawing.Size(775, 327);
            this.dgvEmpleados.TabIndex = 9;
            this.dgvEmpleados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmpleados_CellContentClick);
            // 
            // empleadosBindingSource
            // 
            this.empleadosBindingSource.DataMember = "empleados";
            this.empleadosBindingSource.DataSource = this.starGetsDataSet;
            // 
            // starGetsDataSet
            // 
            this.starGetsDataSet.DataSetName = "StarGetsDataSet";
            this.starGetsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // empleadosTableAdapter
            // 
            this.empleadosTableAdapter.ClearBeforeFill = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(519, 356);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(618, 357);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 11;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(519, 406);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(618, 406);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 12;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "\tNombre del empleado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Apellido paterno";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Apellido materno";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Correo electronico";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Teléfono";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Selección de departamento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 307);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "Selección del rol";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 359);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "Usuario";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 409);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 16);
            this.label9.TabIndex = 22;
            this.label9.Text = "Contraseña";
            // 
            // FormEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 794);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvEmpleados);
            this.Controls.Add(this.cbRol);
            this.Controls.Add(this.cbDepartamento);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtAm);
            this.Controls.Add(this.txtAp);
            this.Controls.Add(this.txtNombre);
            this.Name = "FormEmpleados";
            this.Text = "FormEmpleados";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empleadosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.starGetsDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtAp;
        private System.Windows.Forms.TextBox txtAm;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.ComboBox cbDepartamento;
        private System.Windows.Forms.ComboBox cbRol;
        private System.Windows.Forms.DataGridView dgvEmpleados;
        private StarGetsDataSet starGetsDataSet;
        private System.Windows.Forms.BindingSource empleadosBindingSource;
        private StarGetsDataSetTableAdapters.empleadosTableAdapter empleadosTableAdapter;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}