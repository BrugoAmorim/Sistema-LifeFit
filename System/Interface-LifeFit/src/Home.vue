<script>
import Footer from './components/Footer.vue';
import NavigationBar from './components/NavigationBar.vue';

export default {
  components: {
    Footer,
    NavigationBar
  }
}

</script>

<template>
  <div class="body">
    <NavigationBar />
    <div class="container-one">
      <div class="container-img-desc">
        <div class="container-img"></div>
      </div>
      <div class="container-desc">
        <div class="title">
          <p>Projeto <ins style="color: #62b629">LifeFit</ins></p>
        </div>
        <div class="desc">
          <p>Bem-vindo ao <strong>LifeFit</strong>! Nossa meta é ajudar você a alcançar seus objetivos fitness de forma eficiente e organizada.</p>
        </div>
        <div class="join">
          <button class="btn-start">Crie sua rotina de treino</button>
        </div>
      </div>
    </div>
    <div class="container-two">
      <div class="ctn-desc">
        <div class="ctn-text">
          <p>Crie suas rotinas de treino <span style="color: yellow;">da forma</span> que quiser, com uma interface de <span style="color: yellow;">fácil entendimento</span> que não te <span style="color: yellow;">deixará perdido</span> na hora de usar.</p>
        </div>
        <div class="ctn-button">
          <button class="btn-start-now">Comece a usar agora!</button>
        </div>
      </div>
      <div class="ctn-img">
        <img src="/images/image-fitness-cartoon1.png" alt="imagem ilustrando o exercicio supino com barra" height="100%">
      </div>
    </div>
    <div class="container-three">
      <div class="ctn-img3">
        <img src="/images/image-fitness-cartoon2.png" alt="ilustracao de pessoas treinando" height="100%">
      </div>
      <div class="ctn-desc-site">
        <div class="container-text">
          <p>Nosso sistema permite com que voce crie <span style="color: yellow;">diversas rotinas</span> de treino da <span style="color: yellow;">forma que achar melhor</span>, elas podem ser baixadas para serem usadas <span  style="color: yellow;">onde</span> e <span style="color: yellow;">quando quiser</span>.</p>
        </div>
        <div class="container-button-start">
          <button class="btn-start-now">Comece a usar agora!</button>
        </div>
      </div>
    </div>
    <Footer />
  </div>
</template>

<style scoped src="public/css/home.css"></style>