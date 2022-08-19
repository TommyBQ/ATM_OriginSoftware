import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfoRetiroComponent } from './info-retiro.component';

describe('InfoRetiroComponent', () => {
  let component: InfoRetiroComponent;
  let fixture: ComponentFixture<InfoRetiroComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InfoRetiroComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InfoRetiroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
