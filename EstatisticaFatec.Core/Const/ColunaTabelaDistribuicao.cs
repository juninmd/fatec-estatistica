using System;

namespace EstatisticaFatec.Core.Const
{
    public class ColunaTabelaDistribuicao
    {
        public ColunaTabelaDistribuicao(decimal valorColuna, decimal valorLinha)
        {
            ValorLinha = valorLinha;
            ValorColuna = valorColuna;
        }
        public decimal ValorLinha { get; set; }
        public decimal ValorColuna { get; set; }

        private decimal GetValorLinha(decimal d0, decimal d1, decimal d2, decimal d3, decimal d4, decimal d5, decimal d6, decimal d7, decimal d8, decimal d9)
        {
            if (ValorLinha == new decimal(0.0))
                return d0;
            else if (ValorLinha == new decimal(0.1))
                return d1;
            else if (ValorLinha == new decimal(0.2))
                return d2;
            else if (ValorLinha == new decimal(0.3))
                return d3;
            else if (ValorLinha == new decimal(0.4))
                return d4;
            else if (ValorLinha == new decimal(0.5))
                return d5;
            else if (ValorLinha == new decimal(0.6))
                return d6;
            else if (ValorLinha == new decimal(0.7))
                return d7;
            else if (ValorLinha == new decimal(0.8))
                return d8;
            else if (ValorLinha == new decimal(0.9))
                return d9;

            throw new Exception("aa");
        }

        public decimal GetLinha()
        {
            if (ValorColuna == new decimal(0.0))
                return GetValorLinha(F(0000), F(0040), F(0080), F(00120), F(00160), F(00190), F(0239), F(0279), F(0319), F(0359));
            if (ValorColuna == new decimal(0.1))
                return GetValorLinha(F(0398), F(0438), F(0478), F(0517), F(0557), F(0596), F(0636), F(0675), F(0714), F(0753));
            if (ValorColuna == new decimal(0.2))
                return GetValorLinha(F(0793), F(0832), F(0871), F(0910), F(0948), F(0987), F(1026), F(1064), F(1103), F(1141));
            if (ValorColuna == new decimal(0.3))
                return GetValorLinha( F(1179), F(1217), F(1255), F(1293), F(1331), F(1368), F(1406), F(1443), F(1480), F(1517));
            if (ValorColuna == new decimal(0.4))
                return GetValorLinha(F(1554), F(1591), F(1628), F(1664), F(1700), F(1736), F(1772), F(1808), F(1844), F(1879));
            if (ValorColuna == new decimal(0.5))
                return GetValorLinha(F(1915), F(1950), F(1985), F(2019), F(2054), F(2088), F(2123), F(2157), F(2190), F(2224));
            if (ValorColuna == new decimal(0.6))
                return GetValorLinha(F(2257), F(2291), F(2324), F(2357), F(2389), F(2422), F(2454), F(2486), F(2517), F(2549));
            if (ValorColuna == new decimal(0.7))
                return GetValorLinha(F(2580), F(2611), F(2642), F(2673), F(2704), F(2734), F(2764), F(2794), F(2823), F(2852));
            if (ValorColuna == new decimal(0.8))
                return GetValorLinha(F(2881), F(2910), F(2939), F(2967), F(2995), F(3023), F(3051), F(3078), F(3106), F(3133));
            if (ValorColuna == new decimal(0.9))
                return GetValorLinha(F(3159), F(3186), F(3212), F(3238), F(3264), F(3289), F(3315), F(3340), F(3365), F(3389));
            if (ValorColuna == new decimal(1.0))
                return GetValorLinha(F(3413), F(3438), F(3461), F(3485), F(3508), F(3531), F(3554), F(3577), F(3599), F(3621));
            if (ValorColuna == new decimal(1.1))
                return GetValorLinha(F(3643), F(3665), F(3686), F(3708), F(3729), F(3749), F(3770), F(3790), F(3810), F(3830));
            if (ValorColuna == new decimal(1.2))
                return GetValorLinha(F(3849), F(3869), F(3888), F(3907), F(3925), F(3944), F(3962), F(3980), F(3997), F(4015));
            if (ValorColuna == new decimal(1.3))
                return GetValorLinha(F(4032), F(4049), F(4066), F(4082), F(4099), F(4115), F(4131), F(4147), F(4162), F(4177));
            if (ValorColuna == new decimal(1.4))
                return GetValorLinha(F(4192), F(4207), F(4222), F(4236), F(4251), F(4265), F(4279), F(4292), F(4306), F(4319));
            if (ValorColuna == new decimal(1.5))
                return GetValorLinha(F(4332), F(4345), F(4357), F(4370), F(4382), F(4394), F(4406), F(4418), F(4429), F(4441));
            if (ValorColuna == new decimal(1.6))
                return GetValorLinha(F(4452), F(4463), F(4474), F(4484), F(4495), F(4505), F(4515), F(4525), F(4535), F(4545));
            if (ValorColuna == new decimal(1.7))
                return GetValorLinha(F(4554), F(4564), F(4573), F(4582), F(4591), F(4599), F(4608), F(4616), F(4625), F(4633));
            if (ValorColuna == new decimal(1.8))
                return GetValorLinha(F(4641), F(4649), F(4656), F(4664), F(4671), F(4678), F(4686), F(4693), F(4699), F(4706));
            if (ValorColuna == new decimal(1.9))
                return GetValorLinha(F(4713), F(4719), F(4726), F(4732), F(4738), F(4744), F(4750), F(4756), F(4761), F(4767));
            if (ValorColuna == new decimal(2.0))
                return GetValorLinha(F(4772), F(4778), F(4783), F(4788), F(4793), F(4798), F(4803), F(4808), F(4812), F(4817));
            if (ValorColuna == new decimal(2.1))
                return GetValorLinha(F(4821), F(4826), F(4830), F(4834), F(4838), F(4842), F(4846), F(4850), F(4854), F(4857));
            if (ValorColuna == new decimal(2.2))
                return GetValorLinha(F(4861), F(4864), F(4868), F(4871), F(4875), F(4878), F(4881), F(4884), F(4887), F(4890));
            if (ValorColuna == new decimal(2.3))
                return GetValorLinha(F(4893), F(4896), F(4898), F(4901), F(4904), F(4906), F(4909), F(4911), F(4913), F(4916));
            if (ValorColuna == new decimal(2.4))
                return GetValorLinha(F(4918), F(4920), F(4922), F(4925), F(4927), F(4929), F(4931), F(4932), F(4934), F(4936 ));
            if (ValorColuna == new decimal(2.5))
                return GetValorLinha(F(4938), F(4940), F(4941), F(4943), F(4945), F(4946), F(4948), F(4949), F(4951), F(4952));
            if (ValorColuna == new decimal(2.6))
                return GetValorLinha(F(4953), F(4955), F(4956), F(4957), F(4959), F(4960), F(4961), F(4962), F(4963), F(4964));
            if (ValorColuna == new decimal(2.7))
                return GetValorLinha(F(4965), F(4966), F(4967), F(4968), F(4969), F(4970), F(4971), F(4972), F(4973), F(4974));
            if (ValorColuna == new decimal(2.8))
                return GetValorLinha(F(4974), F(4975), F(4976), F(4977), F(4977), F(4978), F(4979), F(4979), F(4980), F(4981));
            if (ValorColuna == new decimal(2.9))
                return GetValorLinha(F(4981), F(4982), F(4982), F(4983), F(4984), F(4984), F(4985), F(4985), F(4986), F(4986));
            if (ValorColuna == new decimal(3.0))
                return GetValorLinha(F(4987), F(4987), F(4987), F(4988), F(4988), F(4989), F(4989), F(4989), F(4990), F(4990));
            if (ValorColuna >= new decimal(3.1))
                return F(4999);
            return 0;
        }

        private decimal F(decimal number)
        {
            var query = $"0,{number}";
            return decimal.Parse(query);
        }
    }

}
