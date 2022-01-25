﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Espetinho_TCC.DAO;

namespace Espetinho_TCC.Apresentação.Controle_de_Estoque.Entrada_de_Estoque
{
    public partial class frmQtdProdutoEntrada : Form
    {
        ProdutoDAO prodDAO = new ProdutoDAO();

        int idProd;

        public frmQtdProdutoEntrada(int id)
        {
            InitializeComponent();
            idProd = id;
        }

        private void frmQtdProdutoEntrada_Load(object sender, EventArgs e)
        {
            txtQtdEstoque.Text = prodDAO.produtoPorID(idProd).QtdEst_prod.ToString();
            txtQtdProd.Text = "0";
        }

        #region Aumentar e Diminuir Quantidade
        private void txtQtdProd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtQtdEstoque.Text = Convert.ToInt32(prodDAO.Prod.QtdEst_prod + Convert.ToInt32(txtQtdProd.Text)).ToString();
            }
            catch { }
            txtQtdProd.BackColor = Color.Empty;
        }

        private void btnAumentarQtd_Click(object sender, EventArgs e)
        {
            try
            {
                txtQtdProd.Text = (Convert.ToInt32(txtQtdProd.Text) + 1).ToString();
                if (txtQtdProd.Text != "0")
                {
                    if (txtQtdProd.Text == "1")
                    {
                        btnDiminuirQtd.Enabled = false;
                    }
                    if (Convert.ToInt32(txtQtdProd.Text) < 0)
                    {
                        txtQtdProd.Text = (Convert.ToInt32(txtQtdProd.Text) + 1).ToString();
                        MessageBox.Show("Quantidade negativa!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        btnDiminuirQtd.Enabled = true;
                    }
                }
            }
            catch { }
        }

        private void btnDiminuirQtd_Click(object sender, EventArgs e)
        {
            try
            {
                txtQtdProd.Text = (Convert.ToInt32(txtQtdProd.Text) - 1).ToString();
                if (txtQtdProd.Text != "0")
                {
                    if (txtQtdProd.Text == "1")
                    {
                        btnDiminuirQtd.Enabled = false;
                    }
                    if (Convert.ToInt32(txtQtdProd.Text) < 0)
                    {
                        txtQtdProd.Text = (Convert.ToInt32(txtQtdProd.Text) + 1).ToString();
                        MessageBox.Show("Quantidade negativa!!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        btnDiminuirQtd.Enabled = true;
                    }
                }
            }
            catch { }
        }
        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnCancelar.Enabled = false;
            btnContinuar.Enabled = true;
            Close();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            btnCancelar.Enabled = true;
            btnContinuar.Enabled = false;
            Close();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            btnCancelar.PerformClick();
        }
    }
}
