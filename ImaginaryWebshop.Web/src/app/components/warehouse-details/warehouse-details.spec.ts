import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WarehouseDetails } from './warehouse-details';

describe('WarehouseDetails', () => {
  let component: WarehouseDetails;
  let fixture: ComponentFixture<WarehouseDetails>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [WarehouseDetails]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WarehouseDetails);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
