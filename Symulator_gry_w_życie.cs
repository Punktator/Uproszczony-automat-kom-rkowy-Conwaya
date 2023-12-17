using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra_w_życie__Conwaya;

class Symulator_gry_w_życie
{
    internal const uint dlugosc_boku_planszy = 6;

    internal bool[,] plansza = new bool[dlugosc_boku_planszy, dlugosc_boku_planszy];

    internal void Zainicjuj(List<Kordy> lista_korduw) 
    {
        for (uint i = 0; i < dlugosc_boku_planszy; i++)
        {
            for (uint j = 0; j < dlugosc_boku_planszy; j++)
            {           
                plansza[i, j] = false; 
            }
        }

        foreach (Kordy iterator in lista_korduw)
        {
            plansza[iterator.x, iterator.y] = true;
        }
    }

    uint PoliczRzywychSomsiaduw(uint x, uint y)    //w tzw. sąsiedztwie Moore'a
    {
        uint licznik = 0;

        if (x > 0)          //w informatyce zanczynamy od 0
        {
            if (y > 0)
            {
                if (plansza[x - 1, y - 1])
                    licznik++;
            }
            if (y < dlugosc_boku_planszy - 1)
            {
                if (plansza[x-1, y+1])
                    licznik++;
            }
            if (plansza[x - 1, y])
                licznik++;
        }
        if (x < dlugosc_boku_planszy-1)
        {
            if (plansza[x + 1, y])
                licznik++;
            if (y > 0)
            {
                if (plansza[x + 1, y - 1])
                    licznik++;
            }
            if (y < dlugosc_boku_planszy-1)
            {
                if (plansza[x + 1, y + 1])
                    licznik++;
            }
        }
        if (y > 0)
        {
            if (plansza[x, y - 1]) licznik++;
        }
        if (y < dlugosc_boku_planszy-1)
        {
            if (plansza[x, y + 1]) licznik++;
        }

        return licznik;
    }

    protected void Iteruj()
    {
        for (uint i = 0; i<dlugosc_boku_planszy; i++)
        {
            for (uint j = 0; j<dlugosc_boku_planszy; j++)
            {
                uint liczba_rzywych_somsiaduw = PoliczRzywychSomsiaduw(i, j);
                plansza[i, j] = (liczba_rzywych_somsiaduw == 2  ||  liczba_rzywych_somsiaduw == 3);
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

    public Kordy(uint nowy_x, uint nowy_y)
    {
        this.x = nowy_x;
        this.y = nowy_y;
    }

    public static bool operator==(Kordy a, Kordy b)
    {
        return a.x == b.x && a.y == b.y;
    }

    public static bool operator!=(Kordy a, Kordy b)
    {
        return a.x != b.x || a.y != b.y;
    }
}
