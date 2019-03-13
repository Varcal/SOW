using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SOW.NucleoCompartilhado.Modelos
{
    public abstract class ObjetoValor: IEquatable<ObjetoValor>
    {
        public bool Equals(ObjetoValor outro)
        {
            if (outro == null)
                return false;

            var tipo = GetType();
            var outroTipo = outro.GetType();

            if (tipo != outroTipo)
                return false;

            var campos = tipo.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (var campo in campos)
            {
                var valorOutro = campo.GetValue(outro);
                var valorDeste = campo.GetValue(this);

                if (valorOutro == null)
                {
                    if (valorDeste == null)
                        return false;
                }
                else if (!valorOutro.Equals(valorDeste))
                {
                    return false;
                }
            }

            return true;
        }

        #region overrides
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            var outro = obj as ObjetoValor;
            return Equals(outro);
        }

        public override int GetHashCode()
        {
            var campos = ObterCampos();
            const int valorInicial = 17;
            const int multiplicador = 59;

            return campos.Select(campo => campo.GetValue(this))
                .Where(valor => valor != null)
                .Aggregate(valorInicial, (atual, valor) => atual * multiplicador + valor.GetHashCode());
        }

        private IEnumerable<FieldInfo> ObterCampos()
        {
            var tipo = GetType();
            var campos = new List<FieldInfo>();

            while (tipo != typeof(object))
            {
                campos.AddRange(tipo.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
                tipo = tipo.GetTypeInfo().BaseType;
            }

            return campos;
        }
        #endregion
    }
}
