import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PokePicturesComponent } from './poke-pictures.component';

describe('PokePicturesComponent', () => {
  let component: PokePicturesComponent;
  let fixture: ComponentFixture<PokePicturesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PokePicturesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PokePicturesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
