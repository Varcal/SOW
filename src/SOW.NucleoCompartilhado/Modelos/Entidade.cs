namespace SOW.NucleoCompartilhado.Modelos
{
    public abstract class Entidade
    {
        public int Id { get; private set; }

        
        #region overrides

        public override bool Equals(object entidade)
        {
            if (!(entidade is Entidade entidadeTmp))
                return false;
            if (ReferenceEquals(this, entidadeTmp))
                return true;
            if (GetType() != entidadeTmp.GetType())
                return false;
            if (Id == 0 || entidadeTmp.Id == 0)
                return false;

            return Id == entidadeTmp.Id;
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + (Id * 59)).GetHashCode();
        }

        public static bool operator ==(Entidade entidadeA, Entidade entidadeB)
        {
            if (ReferenceEquals(entidadeA, null) && ReferenceEquals(entidadeB, null))
                return true;
            if (ReferenceEquals(entidadeA, null) || ReferenceEquals(entidadeB, null))
                return false;

            return entidadeA.Equals(entidadeB);
        }

        public static bool operator !=(Entidade entidadeA, Entidade entidadeB)
        {
            return !(entidadeA == entidadeB);
        }
        #endregion
    }
}