using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra_w_życie__Conwaya;

class Symulator_gry_w_życie
{
    protected const uint dlugosc_boku_planszy = 6;
    const uint ilosc_somsiaduw_konieczna_do_rzycia = 3;

    internal bool[,] plansza = new bool[dlugosc_boku_planszy, dlugosc_boku_planszy];

    internal void Zainicjuj(List<Kordy> lista_korduw) 
    {
        foreach (var kord in lista_korduw)
        {
            plansza[kord.x, kord.y] = true;
        }
    }

    uint PoliczRzywychSomsiaduw(Kordy kordy_komurki)
    {
        uint licznik = 0;

        if (kordy_komurki.x > 0)          //w informatyce zanczynamy od 0
        {
            if (plansza[kordy_komurki.x - 1, kordy_komurki.y])
                licznik++;
        }
        if (kordy_komurki.x < dlugosc_boku_planszy-1)
        {
            if (plansza[kordy_komurki.x + 1, kordy_komurki.y])
                licznik++;
        }
        if (kordy_komurki.y > 0)
        {
            if (plansza[kordy_komurki.x, kordy_komurki.y - 1]) licznik++;
        }
        if (kordy_komurki.y < dlugosc_boku_planszy-1)
        {
            if (plansza[kordy_komurki.x, kordy_komurki.y + 1]) licznik++;
        }

        return licznik;
    }

    protected void Iteruj()
    {
        var nowe_kordy = new Kordy();

        for (uint i = 0; i<dlugosc_boku_planszy; i++)
        {
            for (uint j = 0; j<dlugosc_boku_planszy; j++)
            {
                nowe_kordy.x = i;
                nowe_kordy.y = j;
                if (PoliczRzywychSomsiaduw(nowe_kordy) == ilosc_somsiaduw_konieczna_do_rzycia)
                    plansza[i, j] = true;
                else plansza[i, j] = false;
            }
        }
    }

    internal void CyklRzycia(uint ilosc_cykli)
    {
        throw new NotImplementedException("no nie zaimplementowane xd");
    }

}

struct Kordy
{
    public uint x;
    public uint y;
}
