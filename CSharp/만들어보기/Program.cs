using 만들어보기;
using System.Text;


Orc info1 = new Orc();
info1.a = "상급오크";
info1.b = 210;
info1.c = 60.3f;
info1.d = 80.2f;
info1.e = '여';

info1.SayMyName();
info1.SayMyinfo();

Orc info2 = new Orc();
info2.a = "하급오크";
info2.b = 140;
info2.c = 72.0f;
info2.d = 24.4f;
info2.e = '남';

info2.SayMyName();
info2.SayMyinfo();