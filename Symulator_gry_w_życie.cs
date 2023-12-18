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

    internal Symulator_gry_w_życie(List<Kordy> lista_korduw)
    {
        Inicjalizuj();

        foreach (Kordy iterator in lista_korduw)
        {
            this.plansza[iterator.x, iterator.y] = true;
        }
    }

    private void Inicjalizuj()
    {
        for (uint i = 0; i < dlugosc_boku_planszy; i++)
        {
            for (uint j = 0; j < dlugosc_boku_planszy; j++)
            {
                this.plansza[i, j] = false;
            }
        }
    }

    internal Symulator_gry_w_życie()
    {
        Inicjalizuj();
    }

    uint PoliczRzywychSomsiaduw(uint x, uint y)    //w tzw. sąsiedztwie Moore'a
    {
        uint licznik = 0;

        if (x > 0)          //w informatyce zanczynamy od 0
        {
            if (y > 0)
            {
                if (this.plansza[x - 1, y - 1])
                    licznik++;
            }
            if (y < dlugosc_boku_planszy - 1)
            {
                if (plansza[x-1, y+1])
                    licznik++;
            }
            if (this.plansza[x - 1, y])
                licznik++;
        }
        if (x < dlugosc_boku_planszy-1)
        {
            if (this.plansza[x + 1, y])
                licznik++;
            if (y > 0)
            {
                if (this.plansza[x + 1, y - 1])
                    licznik++;
            }
            if (y < dlugosc_boku_planszy-1)
            {
                if (this.plansza[x + 1, y + 1])
                    licznik++;
            }
        }
        if (y > 0)
        {
            if (this.plansza[x, y - 1]) licznik++;
        }
        if (y < dlugosc_boku_planszy-1)
        {
            if (this.plansza[x, y + 1]) licznik++;
        }

        return licznik;
    }

    protected void Iteruj()
    {
        Symulator_gry_w_życie nowa_faza = new();

        for (uint i = 0; i<dlugosc_boku_planszy; i++)
        {
            for (uint j = 0; j<dlugosc_boku_planszy; j++)
            {
                uint liczba_rzywych_somsiaduw = PoliczRzywychSomsiaduw(i, j);
                nowa_faza.plansza[i, j] = (liczba_rzywych_somsiaduw == 2  ||  liczba_rzywych_somsiaduw == 3);
            }
        }

        this.plansza = nowa_faza.plansza;
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
