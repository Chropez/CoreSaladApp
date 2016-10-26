import { Routes, RouterModule } from '@angular/router';
import { DataResolver } from './app.resolver';

import { HomeComponent } from './home';
import { AboutComponent } from './about';
import { NoContentComponent } from './no-content';

import { LoginComponent } from './login/login.component';
import { OrdersComponent } from './orders/orders.component';
import { SaladsComponent } from './salads/salads.component';
import { DrinksComponent } from './drinks/drinks.component';

export const ROUTES: Routes = [
  { path: '',      component: HomeComponent },
  { path: 'home',  component: HomeComponent },
  { path: 'about', component: AboutComponent },
  {
    path: 'detail', loadChildren: () => System.import('./+detail')
  },

  { path: 'login', component: LoginComponent },
  { path: 'orders', component: OrdersComponent },
  { path: 'salads', component: SaladsComponent },
  { path: 'drinks', component: DrinksComponent },

  { path: '**',    component: NoContentComponent },
];
