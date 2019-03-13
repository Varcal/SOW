using System;
using System.Text.RegularExpressions;
using SOW.NucleoCompartilhado.DomainEvents.Notifications;

namespace SOW.NucleoCompartilhado.Validacoes
{
    public partial class ValidarSe
    {
        public static DomainNotification NaoEstaVazio(Guid guid, string mensagem)
        {
            return guid == Guid.Empty ? new DomainNotification("GarantirQueNaoEstaVazio", mensagem) : null;
        }

        public static DomainNotification NaoEstaNulo(object objeto, string mensagem)
        {
            return objeto == null ? new DomainNotification("GarantirQueNaoEstaNulo", mensagem) : null;
        }

        public static DomainNotification EstaNulo(object objeto, string mensagem)
        {
            return objeto != null ? new DomainNotification("GarantirQueEstaNulo", mensagem) : null;
        }

        public static DomainNotification EmailEstaValido(string email, string mensagem)
        {
            var emailRegex = @"^([\w\.\-]+)(\w)@([\w\-]+)((\.(\w){2,3})+)$";

            return (!Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase))
                ? new DomainNotification("GarantirQueEmailEstaValido", mensagem)
                : null;
        }

        public static DomainNotification TelefoneEstaValido(string telefone, string mensagem)
        {
            var regex = new Regex(@"^[0-9]{10}$");

            return (!regex.IsMatch(telefone))
                ? new DomainNotification("GarantirQueTelefoneEstaValido", mensagem)
                : null;
        }

        public static DomainNotification CelularEstaValido(string celular, string mensagem)
        {
            var regex = new Regex(@"^[0-9]{11}$");

            return (!regex.IsMatch(celular))
                ? new DomainNotification("GarantirQueCelularEstaValido", mensagem)
                : null;
        }

        public static DomainNotification CnpjEstaValido(string cnpj, string mensagem)
        {
            return (!EhCnpj(cnpj))
                ? new DomainNotification("GarantirQueCNPJEstaValido", mensagem)
                : null;
        }
        private static bool EhCnpj(string cnpj)
        {
            var multiplicador1 = new[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14) return false;

            var tempCnpj = cnpj.Substring(0, 12);

            soma = 0;
            for (var i = 0; i < 12; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            }

            resto = (soma % 11);

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            var digito = resto.ToString();

            tempCnpj = tempCnpj + digito;

            soma = 0;
            for (var i = 0; i < 13; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            }

            resto = (soma % 11);

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = digito + resto;

            return cnpj.EndsWith(digito);
        }

        public static DomainNotification CpfEstaVaido(string cpf, string mensagem)
        {
            return (!ValidarCpf(cpf)) ? new DomainNotification("GarantirQueCPFEstaValido", mensagem) : null;
        }

        private static bool ValidarCpf(string cpf)
        {
            var multiplicador1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            if (cpf.Length != 11) return false;

            var tempCpf = cpf.Substring(0, 9);
            var soma = 0;

            for (var i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            }

            var resto = soma % 11;

            resto = resto < 2 ? 0 : 11 - resto;

            var digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for (var i = 0; i < 10; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito = digito + resto;

            return cpf.EndsWith(digito);
        }

        public static DomainNotification PisEstaValido(string pis, string mensagem)
        {
            return (!EhPis(pis)) ? new DomainNotification("GarantirQuePISEstaValido", mensagem) : null;
        }
        private static bool EhPis(string pis)
        {
            var multiplicador = new[] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            if (pis.Trim().Length != 11) return false;

            pis = pis.Trim();
            pis = pis.Replace("-", "").Replace(".", "").PadLeft(11, '0');

            var soma = 0;
            for (var i = 0; i < 10; i++)
            {
                soma += int.Parse(pis[i].ToString()) * multiplicador[i];
            }

            var resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            return pis.EndsWith(resto.ToString());
        }

        public static DomainNotification DuracaoEstaValida(int duracao, int intervalo, string mensagem)
        {
            if (intervalo == 0)
            {
                throw new DivideByZeroException("Não é permitido divisão de número por 0");
            }

            var resto = duracao % intervalo;

            return resto != 0 ? new DomainNotification("GarantirQueDuracaoEstaValida", mensagem) : null;
        }

        public static DomainNotification Verdadeiro(bool valor, string menssagem)
        {
            return !valor ? new DomainNotification("GarantirQueVerdadeiro", menssagem) : null;
        }
    }
}
