<template >
  <el-steps :active="active" class="container bg-danger" finish-status="success">
    <el-step title="Paso 1" />
    <el-step title="Paso 2" />
    <el-step title="Paso 3" />
  </el-steps>
  <div class="container bg-danger">
    <el-button style="margin-top: 12px"  @click="next">Next step</el-button>
  </div>
</template>
<script>
export default ({
    setup() {
        
    },
})
</script>

