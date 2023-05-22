import { Injectable } from '@angular/core';
import { Recept, ReceptService } from '../recept.service';
import { map, tap } from 'rxjs/operators';
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Kategoria, KategoriaService } from '../kategoria.service';

@Injectable({
  providedIn: 'root',
})
export class DataStorageService {
  constructor(
    private http: HttpClient,
    private receptService: ReceptService,
    private kategoriaService: KategoriaService
  ) {}

  fetchKategoriak() {
    console.log('fetching kategoriak');

    this.http
      .get<
        {
          id: number;
          nev: string;
        }[]
      >(URL + '/kategoria')
      .pipe(
        map((kategoriak) => {
          const kategoriaData = kategoriak.map((kategoria) => {
            const record: Kategoria = {
              id: kategoria.id,
              nev: kategoria.nev,
            };
            return { ...record };
          });
          return kategoriaData;
        }),
        tap({
          next: (data) => {
            this.kategoriaService.setKategoriak(data.slice());
          },
          error: (error) => console.log(error),
        })
      )
      .subscribe();
  }

  fetchReceptek() {
    console.log('fetching receptek');

    this.http
      .get<
        {
          id: number;
          nev: string;
          katId: number;
          kepEleresiUt: string;
          leiras: string;
          kat: {
            id: number;
            nev: string;
          };
        }[]
      >(URL + '/recept')
      .pipe(
        map((receptek) => {
          const receptData = receptek.map((recept) => {
            const record: Recept = {
              id: recept.id,
              nev: recept.nev,
              katId: recept.katId,
              kepEleresiUt: recept.kepEleresiUt,
              leiras: recept.leiras,
              kat: recept.kat,
            };
            return { ...record };
          });
          return receptData;
        }),
        tap({
          next: (data) => {
            this.receptService.setReceptek(data.slice());
          },
          error: (error) => console.log(error),
        })
      )
      .subscribe();
  }

  newRecept(recept: Recept) {
    return this.http
      .post<any>(URL + '/recept', {
        nev: recept.nev,
        katId: recept.katId,
        kepEleresiUt: recept.kepEleresiUt,
        leiras: recept.leiras,
      })
      .pipe(
        tap({
          next: (res) => {
            if (res) {
              this.fetchReceptek();
              console.log(res);
            }
          },
          error: (error) => {
            console.log(error);
            this.receptService.error.next('Hiba történt felvitelkor.');
          },
        })
      )
      .subscribe();
  }

  deleteRecept(id: number) {
    return this.http
      .delete<any>(URL + '/recept/' + id)
      .pipe(
        tap({
          next: (res: number) => {
            console.log('deleted: ' + res);
            if (res > 0) {
              this.receptService.deleteRecept(id);
            }
          },
          error: (error) => console.log(error),
        })
      )
      .subscribe();
  }
}
export const URL = 'https://localhost:44335/api';
