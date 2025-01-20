import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './user/view/login/login.component';
import { ShippingQuoteComponent } from './shippingQuotes/view/shipping-quote/shipping-quote.component';
import { UserComponent } from './user/view/user/user.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/login',
    pathMatch: 'full',
  }, // Redirige a la página de login por defecto
  {
    path: 'register-user',
    component: UserComponent,
  }, // Ruta para LoginComponent
  {
    path: 'login',
    component: LoginComponent,
  }, // Ruta para LoginComponent
  {
    path: 'shipping-quote',
    component: ShippingQuoteComponent,
  }, // Ruta para ShippingQuoteComponent
  {
    path: '**',
    redirectTo: '/login',
  }, // Redirige a login si no encuentra la ruta
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
