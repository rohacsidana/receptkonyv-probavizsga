import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class KategoriaService {
  private kategoriaData: Kategoria[] = [];
  kategoriaDataChanged: Subject<Kategoria[]> = new Subject<Kategoria[]>();
  error: Subject<string> = new Subject<string>();

  getKategoriak() {
    return this.kategoriaData.slice();
  }

  setKategoriak(kategoriak: Kategoria[]) {
    this.kategoriaData = kategoriak;
    this.kategoriaData.forEach(kat => {
      kat.nev =kat.nev[0].toUpperCase() + kat.nev.substring(1);
    });
    this.kategoriaDataChanged.next(this.kategoriaData);
    console.log(this.kategoriaData);
  }
}

export interface Kategoria {
  id: number;
  nev: string;
}
