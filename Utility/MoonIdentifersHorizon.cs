using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace OurSolarSystemAPI.Utility
{
    public struct MoonIdentifiers
    {
        public int ID;
        public string Name;
        public string Designation;

        public MoonIdentifiers(int id, string name, string designation)
        {
            ID = id;
            Name = name;
            Designation = designation;
        }
    }


    public class PlanetContainer
    {
        public string Name;
        public List<MoonIdentifiers> Moons;

        public PlanetContainer(string name, List<MoonIdentifiers> moons)
        {
            Name = name;
            Moons = moons;
        }

        public List<PlanetContainer> InstantiatePlanetAndMoonStructs() 
        {
            var earthMoons = new List<MoonIdentifiers>
            {
                new MoonIdentifiers(301, "Moon", "Luna")
            };

            var marsMoons = new List<MoonIdentifiers>
            {
                new MoonIdentifiers(401, "Phobos", "MI"),
                new MoonIdentifiers(402, "Deimos", "MII")
            };

            var jupiterMoons = new List<MoonIdentifiers>
            {
                new MoonIdentifiers(501, "Io", "JI"),
                new MoonIdentifiers(502, "Europa", "JII"),
                new MoonIdentifiers(503, "Ganymede", "JIII"),
                new MoonIdentifiers(504, "Callisto", "JIV"),
                new MoonIdentifiers(505, "Amalthea", "JV"),
                new MoonIdentifiers(506, "Himalia", "JVI"),
                new MoonIdentifiers(507, "Elara", "JVII"),
                new MoonIdentifiers(508, "Pasiphae", "JVIII"),
                new MoonIdentifiers(509, "Sinope", "JIX"),
                new MoonIdentifiers(510, "Lysithea", "JX"),
                new MoonIdentifiers(511, "Carme", "JXI"),
                new MoonIdentifiers(512, "Ananke", "JXII"),
                new MoonIdentifiers(513, "Leda", "JXIII"),
                new MoonIdentifiers(514, "Thebe", "JXIV"),
                new MoonIdentifiers(515, "Adrastea", "JXV"),
                new MoonIdentifiers(516, "Metis", "JXVI"),
                new MoonIdentifiers(517, "Callirrhoe", "JXVII"),
                new MoonIdentifiers(518, "Themisto", "JXVIII"),
                new MoonIdentifiers(519, "Megaclite", "JXIX"),
                new MoonIdentifiers(520, "Taygete", "JXX"),
                new MoonIdentifiers(521, "Chaldene", "JXXI"),
                new MoonIdentifiers(522, "Harpalyke", "JXXII"),
                new MoonIdentifiers(523, "Kalyke", "JXXIII"),
                new MoonIdentifiers(524, "Iocaste", "JXXIV"),
                new MoonIdentifiers(525, "Erinome", "JXXV"),
                new MoonIdentifiers(526, "Isonoe", "JXXVI"),
                new MoonIdentifiers(527, "Praxidike", "JXXVII"),
                new MoonIdentifiers(528, "Autonoe", "JXXVIII"),
                new MoonIdentifiers(529, "Thyone", "JXXIX"),
                new MoonIdentifiers(530, "Hermippe", "JXXX"),
                new MoonIdentifiers(531, "Aitne", "JXXXI"),
                new MoonIdentifiers(532, "Eurydome", "JXXXII"),
                new MoonIdentifiers(533, "Euanthe", "JXXXIII"),
                new MoonIdentifiers(534, "Euporie", "JXXXIV"),
                new MoonIdentifiers(535, "Orthosie", "JXXXV"),
                new MoonIdentifiers(536, "Sponde", "JXXXVI"),
                new MoonIdentifiers(537, "Kale", "JXXXVII"),
                new MoonIdentifiers(538, "Pasithee", "JXXXVIII"),
                new MoonIdentifiers(539, "Hegemone", "JXXXIX"),
                new MoonIdentifiers(540, "Mneme", "JXL"),
                new MoonIdentifiers(541, "Aoede", "JXLI"),
                new MoonIdentifiers(542, "Thelxinoe", "JXLII"),
                new MoonIdentifiers(543, "Arche", "JXLIII"),
                new MoonIdentifiers(544, "Kallichore", "JXLIV"),
                new MoonIdentifiers(545, "Helike", "JXLV"),
                new MoonIdentifiers(546, "Carpo", "JXLVI"),
                new MoonIdentifiers(547, "Eukelade", "JXLVII"),
                new MoonIdentifiers(548, "Cyllene", "JXLVIII"),
                new MoonIdentifiers(549, "Kore", "JXLIX"),
                new MoonIdentifiers(550, "Herse", "JXLXII"),
                new MoonIdentifiers(551, "(Unnamed 2010J1)", "JLI"),
                new MoonIdentifiers(552, "(Unnamed 2010J2)", "JLII"),
                new MoonIdentifiers(553, "Dia", "JLIII"),
                new MoonIdentifiers(554, "(Unnamed 2016J1)", "JLIV"),
                new MoonIdentifiers(555, "(Unnamed 2003J18)", "JLV"),
                new MoonIdentifiers(556, "(Unnamed 2011J2)", "JLVI"),
                new MoonIdentifiers(557, "Eirene", "JLVII"),
                new MoonIdentifiers(558, "Philophrosyne", "JLVIII"),
                new MoonIdentifiers(559, "(Unnamed 2017J1)", "JLIX"),
                new MoonIdentifiers(560, "Eupheme", "JLX"),
                new MoonIdentifiers(561, "(Unnamed 2003J19)", ""),
                new MoonIdentifiers(562, "Valetudo", ""),
                new MoonIdentifiers(563, "(Unnamed 2017J2)", ""),
                new MoonIdentifiers(564, "(Unnamed 2017J3)", ""),
                new MoonIdentifiers(565, "Pandia", "JLXV"),
                new MoonIdentifiers(566, "(Unnamed 2017J5)", ""),
                new MoonIdentifiers(567, "(Unnamed 2017J6)", ""),
                new MoonIdentifiers(568, "(Unnamed 2017J7)", ""),
                new MoonIdentifiers(569, "(Unnamed 2017J8)", ""),
                new MoonIdentifiers(570, "(Unnamed 2017J9)", "JLXX"),
                new MoonIdentifiers(571, "Ersa", ""),
                new MoonIdentifiers(572, "(Unnamed 2011J1)", "")
            };

            var saturnMoons = new List<MoonIdentifiers> 
            {
                new MoonIdentifiers(601, "Mimas", "SI"),
                new MoonIdentifiers(602, "Enceladus", "SII"),
                new MoonIdentifiers(603, "Tethys", "SIII"),
                new MoonIdentifiers(604, "Dione", "SIV"),
                new MoonIdentifiers(605, "Rhea", "SV"),
                new MoonIdentifiers(606, "Titan", "SVI"),
                new MoonIdentifiers(607, "Hyperion", "SVII"),
                new MoonIdentifiers(608, "Iapetus", "SVIII"),
                new MoonIdentifiers(609, "Phoebe", "SIX"),
                new MoonIdentifiers(610, "Janus", "SX"),
                new MoonIdentifiers(611, "Epimetheus", "SXI"),
                new MoonIdentifiers(612, "Helene", "SXII"),
                new MoonIdentifiers(613, "Telesto", "SXIII"),
                new MoonIdentifiers(614, "Calypso", "SXIV"),
                new MoonIdentifiers(615, "Atlas", "SXV"),
                new MoonIdentifiers(616, "Prometheus", "SXVI"),
                new MoonIdentifiers(617, "Pandora", "SXVII"),
                new MoonIdentifiers(618, "Pan", "SXVIII"),
                new MoonIdentifiers(619, "Ymir", "SXIX"),
                new MoonIdentifiers(620, "Paaliaq", "SXX"),
                new MoonIdentifiers(621, "Tarvos", "SXXI"),
                new MoonIdentifiers(622, "Ijiraq", "SXXII"),
                new MoonIdentifiers(623, "Suttungr", "SXXIII"),
                new MoonIdentifiers(624, "Kiviuq", "SXXIV"),
                new MoonIdentifiers(625, "Mundilfari", "SXXV"),
                new MoonIdentifiers(626, "Albiorix", "SXXVI"),
                new MoonIdentifiers(627, "Skathi", "SXXVII"),
                new MoonIdentifiers(628, "Erriapus", "SXXVIII"),
                new MoonIdentifiers(629, "Siarnaq", "SXXIX"),
                new MoonIdentifiers(630, "Thrymr", "SXXX"),
                new MoonIdentifiers(631, "Narvi", "SXXXI"),
                new MoonIdentifiers(632, "Methone", "SXXXII"),
                new MoonIdentifiers(633, "Pallene", "SXXXIII"),
                new MoonIdentifiers(634, "Polydeuces", "SXXXIV"),
                new MoonIdentifiers(635, "Daphnis", "SXXXV"),
                new MoonIdentifiers(636, "Aegir", "SXXXVI"),
                new MoonIdentifiers(637, "Bebhionn", "SXXXVII"),
                new MoonIdentifiers(638, "Bergelmir", "SXXXVIII"),
                new MoonIdentifiers(639, "Bestla", "SXXXIX"),
                new MoonIdentifiers(640, "Farbauti", "SXL"),
                new MoonIdentifiers(641, "Fenrir", "SXLII"),
                new MoonIdentifiers(642, "Fornjot", "SXLIII"),
                new MoonIdentifiers(643, "Hati", "SXLV"),
                new MoonIdentifiers(644, "Unnamed 2004S26", "SXLVI"),
                new MoonIdentifiers(645, "Kari", "SXLVII"),
                new MoonIdentifiers(646, "Unnamed 2007S3", "SXLVIII"),
                new MoonIdentifiers(647, "Loge", "SXLIX"),
                new MoonIdentifiers(648, "Skoll", "SXLX"),
                new MoonIdentifiers(649, "Surtur", "SXLXI"),
                new MoonIdentifiers(650, "Anthe", "SXLXII"),
                new MoonIdentifiers(651, "Unnamed 2004S20", "SXLXIII"),
                new MoonIdentifiers(652, "Unnamed 2006S1", "SXLXIV"),
                new MoonIdentifiers(653, "Unnamed 2004S23", "SXLXV") 
            };

            var uranusMoons = new List<MoonIdentifiers> 
            {
                new MoonIdentifiers(701, "Miranda", "UI"),
                new MoonIdentifiers(702, "Ariel", "UII"),
                new MoonIdentifiers(703, "Umbriel", "UIII"),
                new MoonIdentifiers(704, "Titania", "UIV"),
                new MoonIdentifiers(705, "Oberon", "UV"),
                new MoonIdentifiers(706, "Caliban", "UVI"),
                new MoonIdentifiers(707, "Sycorax", "UVII"),
                new MoonIdentifiers(708, "Prospero", "UVIII"),
                new MoonIdentifiers(709, "Setebos", "UIX"),
                new MoonIdentifiers(710, "Stephano", "UX"),
                new MoonIdentifiers(711, "Trinculo", "UXI"),
                new MoonIdentifiers(712, "Francisco", "UXII"),
                new MoonIdentifiers(713, "Margaret", "UXIII"),
                new MoonIdentifiers(714, "Ferdinand", "UXIV"),
                new MoonIdentifiers(715, "Perdita", "UXV"),
                new MoonIdentifiers(716, "Mab", "UXVI"),
                new MoonIdentifiers(717, "Cupid", "UXVII")
            };

            var neptuneMoons = new List<MoonIdentifiers> 
            {
                new MoonIdentifiers(801, "Triton", "NI"),
                new MoonIdentifiers(802, "Nereid", "NII"),
                new MoonIdentifiers(803, "Naiad", "NIII"),
                new MoonIdentifiers(804, "Thalassa", "NIV"),
                new MoonIdentifiers(805, "Despina", "NV"),
                new MoonIdentifiers(806, "Galatea", "NVI"),
                new MoonIdentifiers(807, "Larissa", "NVII"),
                new MoonIdentifiers(808, "Proteus", "NVIII"),
                new MoonIdentifiers(809, "Halimede", "NIX"),
                new MoonIdentifiers(810, "Psamathe", "NX"),
                new MoonIdentifiers(811, "Sao", "NXI"),
                new MoonIdentifiers(812, "Laomedeia", "NXII"),
                new MoonIdentifiers(813, "Neso", "NXIII")
            };

            return new List<PlanetContainer>
            {
                new PlanetContainer("earth", earthMoons),
                new PlanetContainer("mars", marsMoons),
                new PlanetContainer("jupiter", jupiterMoons),
                new PlanetContainer("saturn", saturnMoons),
                new PlanetContainer("uranus", uranusMoons),
                new PlanetContainer("neptune", neptuneMoons)
            };                   
        }
    }
}
