import {Component, ElementRef, Renderer2} from '@angular/core';
import {PrimeNGConfig} from "primeng/api";
import {CookieService} from "ngx-cookie-service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'SurveysPortalWeb';
  topbarTheme = 'light';

  menuTheme = 'light';

  layoutMode = 'light';

  menuMode = 'static';

  isRTL = false;

  inputStyle = 'outlined';

  //ripple: boolean;

  constructor(private primengConfig: PrimeNGConfig, private cookieService: CookieService,
              private renderer: Renderer2, private el: ElementRef) {
  }

  ngOnInit() {
    this.primengConfig.ripple = true;
    let layout = this.cookieService.get("layout-mode");
    this.layoutMode = (!layout) ? 'light' : layout;
    const linkElement = this.renderer.createElement('link');

    // Set attributes for the link element
    this.renderer.setAttribute(linkElement, 'id', 'layout-css');
    this.renderer.setAttribute(linkElement, 'rel', 'stylesheet');
    this.renderer.setAttribute(linkElement, 'type', 'text/css');
    this.renderer.setAttribute(linkElement, 'href', './assets/layout/css/layout-' + this.layoutMode +'.css');

    // Append the link element to the head of the document
    this.renderer.appendChild(document.head, linkElement);

  }
}
