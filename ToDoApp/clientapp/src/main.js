import { createApp } from 'vue'
import App from './App.vue'


/* import the fontawesome core */
import { library } from '@fortawesome/fontawesome-svg-core'

/* import font awesome icon component */
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

/* import specific icons */
import { faLocationDot } from '@fortawesome/free-solid-svg-icons'
import {faCalendarDays, faCheckCircle, faPenToSquare, faTrashCan, faPlusSquare, faClock} from '@fortawesome/free-regular-svg-icons'

/* add icons to the library */
library.add(faLocationDot, faCalendarDays, faCheckCircle, faPenToSquare, faTrashCan, faPlusSquare, faClock)

createApp(App)
.component('font-awesome-icon', FontAwesomeIcon)
.mount('#app')
