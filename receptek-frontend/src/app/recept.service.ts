import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ReceptService {
  private receptData: Recept[] = [];
  receptDataChanged: Subject<Recept[]> = new Subject<Recept[]>();
  error: Subject<string> = new Subject<string>();

  getReceptek() {
    return this.receptData.slice();
  }

  setReceptek(receptek: Recept[]) {
    this.receptData = receptek;
    console.log(this.receptData);

    this.dataChanged();
  }

  saveRecept(recept: Recept) {
    this.receptData.push(recept);
    this.dataChanged();
  }

  deleteRecept(id: number) {
    this.receptData.forEach(function (item, index, object) {
      if (item.id === id) {
        object.splice(index, 1);
      }
    });
    this.dataChanged();
  }

  dataChanged() {
    this.receptDataChanged.next(this.receptData.slice());
  }
}
export interface Recept {
  id: number;
  nev: string;
  katId: number;
  kepEleresiUt: string;
  leiras: string;
  kat: {
    id: number;
    nev: string;
  };
}
