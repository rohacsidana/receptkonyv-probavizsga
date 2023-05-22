import { Component, OnDestroy, OnInit } from '@angular/core';
import { DataStorageService } from './data-storage/data-storage.service';
import { Recept, ReceptService } from './recept.service';
import { Kategoria, KategoriaService } from './kategoria.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css', './boot.css'],
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'receptek';

  receptData: Recept[] = this.receptService.getReceptek();
  receptDataSub: Subscription | undefined;

  kategoriaData: Kategoria[] = this.kategoriaService.getKategoriak();
  kategoriaDataSub: Subscription | undefined;

  receptekToShow: Recept[] = this.receptData;
  katIdToShow = -1;

  selectedRecept: Recept | undefined;

  constructor(
    private dataService: DataStorageService,
    private receptService: ReceptService,
    private kategoriaService: KategoriaService
  ) {}

  receptSzures(id: number) {
    //console.log('id:' + id);

    if (id === -1) {
      this.receptekToShow = this.receptData;
    } else {
      let temporaryReceptek: Recept[] = [];
      this.receptData.forEach((recept) => {
        if (recept.katId === id) {
          temporaryReceptek.push(recept);
        }
      });
      this.receptekToShow = temporaryReceptek;
    }
    //console.log(this.receptekToShow);
  }

  receptKivalaszt(recept: Recept) {
    this.selectedRecept = recept
  }

  ngOnInit(): void {
    this.receptDataSub = this.receptService.receptDataChanged.subscribe(
      (receptData: Recept[]) => {
        this.receptData = receptData;
        this.receptekToShow = this.receptData;
      }
    );
    this.kategoriaDataSub =
      this.kategoriaService.kategoriaDataChanged.subscribe(
        (kategoriaData: Kategoria[]) => {
          this.kategoriaData = kategoriaData;
        }
      );

    this.dataService.fetchReceptek();
    this.dataService.fetchKategoriak();
    //console.log(this.kategoriaData);
  }

  ngOnDestroy() {
    this.kategoriaDataSub?.unsubscribe();
    this.receptDataSub?.unsubscribe();
  }
}
